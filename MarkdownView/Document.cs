using System;
using System.Collections.Generic;
using System.Text;
//
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Web;
//
using MarkdownView.Translator;

namespace MarkdownView
{
	class Document
	{
		public event EventHandler Opened;
		public event EventHandler Closed;
		public event EventHandler Updated;
		
		/// <summary>
		/// 更新通知イベントの同期用
		/// </summary>
		private ISynchronizeInvoke _form;

		/// <summary>
		/// 開いているファイルのファイル名
		/// </summary>
        private string _filename = string.Empty;

		/// <summary>
		/// 開いているファイルの内容
		/// </summary>
		private string _input = string.Empty;

		/// <summary>
		/// 作成した一時ファイルの一覧
		/// </summary>
        private HashSet<string> _tmpset = new HashSet<string>();

		/// <summary>
		/// ディレクトリ監視
		/// </summary>
        private FileSystemWatcher _watcher = null;

		/// <summary>
		/// トランスレーター
		/// </summary>
		private TranslatorInterface _translator = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
        public Document(ISynchronizeInvoke form)
        {
			_form = form;
			_translator = new StandardTranslator();
        }

		/// <summary>
		/// デストラクタ
		/// </summary>
        ~Document()
        {
            ClearTempList();
        }

		/// <summary>
		/// トランスレーター
		/// </summary>
		public TranslatorInterface Translator
		{
			get
			{
				return _translator;
			}

			set
			{
				_translator = value;

				if (this.Closed != null)
				{
					this.Closed(this, new EventArgs());
				}

				if (this.Opened != null)
				{
					this.Opened(this, new EventArgs());
				}
			}
		}

        /// <summary>
		/// 一時ファイルを削除する
        /// </summary>
		private void ClearTempList()
        {
            foreach (string fn in _tmpset)
            {
                if (File.Exists(fn))
                {
					try
					{
						File.Delete(fn);
					}
					catch (SystemException ex)
					{
						Trace.WriteLine(ex.Message);
					}
                }
            }

            _tmpset.Clear();
        }

		/// <summary>
		/// ファイルを開く
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="System.SystemException"></exception>
        public void Open(string path)
        {
			Close();
			
			try
			{
				path = Path.GetFullPath(path);
				string dir = Path.GetDirectoryName(path);
				string fn = Path.GetFileName(path);

				// ディレクトリ監視
				_watcher = new FileSystemWatcher(dir);

				// ファイルの書き込みのみを監視
				// @goto ファイルの移動とかも監視する
				_watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.FileName;

				// サブフォルダは監視しない
				_watcher.IncludeSubdirectories = false;

				// コールバック
				_watcher.Changed += new FileSystemEventHandler(FileSystemWatcher_Changed);
				_watcher.Deleted += new FileSystemEventHandler(FileSystemWatcher_Deleted);
				_watcher.Renamed += new RenamedEventHandler(FileSystemWatcher_Renamed);

				// 非同期用にUIスレッドにマーシャリング
				_watcher.SynchronizingObject = _form;

				// 監視を開始
				_watcher.EnableRaisingEvents = true;

				// ファイル名
				_filename = path;

				// ファイルの読み込み
				_input = ReadFile();

				if (Opened != null)
				{
					Opened(this, new EventArgs());
				}
			}
			catch (Exception ex)
			{
				Close();
				throw ex;
			}
        }

		/// <summary>
		/// ファイルを閉じる
		/// </summary>
        public void Close()
        {
			bool opened = IsOpen();

            if (_watcher != null)
            {
                _watcher.Dispose();
                _watcher = null;
			}

			_filename = string.Empty;
			_input = string.Empty;

			ClearTempList();

			if (opened)
			{
				if (Closed != null)
				{
					Closed(this, new EventArgs());
				}
			}
        }

		/// <summary>
		/// ファイルが開かれているかどうかを返す
		/// </summary>
		/// <returns></returns>
        public bool IsOpen()
        {
            return _filename.Length > 0;
        }

		/// <summary>
		/// 開いているファイル名を返す
		/// </summary>
		/// <returns></returns>
        public string GetFilename()
        {
            return _filename;
        }

		/// <summary>
		/// ファイルの内容を読み込む
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.SystemException"></exception>
        private string ReadFile()
        {
            Debug.Assert(_filename.Length > 0);
			
			using (var fs = new FileStream(_filename, FileMode.Open, FileAccess.Read))
			{
				using (var reader = new StreamReader(fs))
				{
					return reader.ReadToEnd();
				}
			}
        }

		/// <summary>
		/// ファイルをリロード
		/// </summary>
		/// <exception cref="System.SystemException"></exception>
		public void Reload()
		{
			_input = ReadFile();
		}

		/// <summary>
		/// 変数を適用したHTMLを取得
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		private string ApplyHtml(string body)
		{
			string html = Properties.Resources.html;

			string appdir = System.Windows.Forms.Application.StartupPath;

			string cssfn = Path.Combine(appdir, _translator.CustomCssFilename);

			if (File.Exists(cssfn) == false)
			{
				cssfn = Path.Combine(appdir, _translator.DefaultCssFilename);
			}

			html = html.Replace("{$css}", HttpUtility.HtmlEncode(new Uri(cssfn).AbsoluteUri));
			html = html.Replace("{$body}", body);

			return html;
		}

		/// <summary>
		/// 変数を適用したBODYを取得
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		private string ApplyBody(string article)
		{
			string body = Properties.Resources.body;

			body = body.Replace("{$article}", article);

			return body;
		}


		/// <summary>
		/// ボディのみのHTMLを取得
		/// </summary>
		/// <returns></returns>
        public string GetInnerHtml()
        {
            if (IsOpen())
            {
				return ApplyBody(_translator.Transform(_input));
            }
            else
            {
				// ドキュメントコンプリートで読んでいるのでファイルを閉じた後でも呼ばれることがある
                return string.Empty;
            }
        }

		/// <summary>
		/// 枠のみのHTMLを取得
		/// </summary>
		/// <returns></returns>
		public string GetContainerHtml()
		{
			return ApplyHtml(string.Empty);
		}

		/// <summary>
		/// 完全なHTMLを取得
		/// </summary>
		/// <returns></returns>
        public string GetCombineHtml()
        {
			return ApplyHtml(GetInnerHtml());
        }

		/// <summary>
		/// 更新監視で通知されたファイル名が今開いているものと一致するか確認
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private bool IsMatchFilename(string name)
		{
			if (_filename.Length == 0)
			{
				// ファイルではなくディレクトリの監視なので deleted → changed のような通知もありうる
				return false;
			}
			else
			{
				// @goto この方法は多分正確ではない
				return Path.GetFileName(_filename).ToLower() == name.ToLower();
			}
		}

		/// <summary>
		/// 更新監視 ファイルの変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
			Debug.WriteLine("watcher changed: " + e.Name);

			if (IsMatchFilename(e.Name))
			{
				if (Updated != null)
				{
					Updated(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// 更新監視 ファイルの削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
			Debug.WriteLine("watcher deleted: " + e.Name);

			if (IsMatchFilename(e.Name))
			{
				Close();
			}
		}

		/// <summary>
		/// 更新監視 ファイルのリネーム
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
		{
			if (IsMatchFilename(e.OldName))
			{
				Debug.WriteLine("watcher renamed: " + e.OldName + " -> " + e.Name);

				Close();
				Open(e.FullPath);
			}
		}

		/// <summary>
		/// テンポラリにエクスポート
		/// </summary>
		/// <param name="tmpdir"></param>
		/// <returns></returns>
		/// <exception cref="System.SystemException"></exception>
        public string ExportTempFile(string tmpdir)
        {
			Debug.Assert(IsOpen());

            string tmp = tmpdir;

            string fn = GetFilename();

            using (var sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                byte[] bytes = sha1.ComputeHash(Encoding.Default.GetBytes(fn));

                string str = ToHexString(bytes);

                tmp = Path.Combine(tmp, str);
            }
            
            tmp = Path.ChangeExtension(tmp, "html");

            string html = GetCombineHtml();

            using (var writer = new StreamWriter(tmp))
            {
                writer.Write(html);
            }

            _tmpset.Add(tmp);
            
            return tmp;
        }

        /// <summary>
        /// バイト配列から16進数文字列を返す
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string ToHexString(byte[] bytes)
        {
            var str = new StringBuilder();

            foreach (byte b in bytes)
            {
                str.AppendFormat("{0:x2}", b);
            }

            return str.ToString();
        }
    }
}
