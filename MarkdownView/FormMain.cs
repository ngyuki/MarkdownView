using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
using System.Diagnostics;
using System.Reflection;
using MarkdownView.Properties;

namespace MarkdownView
{
    public partial class FormMain : Form
    {
		private Document _document;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
			InitializeComponent();
            
            // ドキュメントのイベントハンドラ
			_document = new Document(this);
            _document.Opened += new EventHandler(Document_Opened);
            _document.Closed += new EventHandler(Document_Closed);
            _document.Updated += new EventHandler(Document_Updated);

			// ユーザ設定の読込
			SettingLoad();

			// ブラウザの初期化
			uiWebBrowser.Dock = DockStyle.Fill;

			// コマンドライン引数
			string[] args = Environment.GetCommandLineArgs();

			if (args.Length > 1)
			{
				try
				{
					_document.Open(args[1]);
				}
				catch (Exception ex)
				{
					// Main まで抜ける
					throw ex;
				}
			}

			// コントロール状態更新
			UpdateControlState();
		}
		
		/// <summary>
        /// FormClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ユーザ設定を保存
            SettingSave();
        }

        /// <summary>
        /// ユーザ設定の読み込み
        /// </summary>
        private void SettingLoad()
        {
            var setting = Settings.Default;

            if (setting.WindowBounds.IsEmpty == false)
            {
				Bounds = AdjustmentWindowBounds(setting.WindowBounds);
            }
			
			WindowState = setting.WindowState;
            
            uiButtonMonitor.Checked = setting.AutoReload;
			uiButtonWebApi.Checked = setting.WebApiFlg && setting.WebApiUrl.Length > 0;

			if (uiButtonWebApi.Checked)
			{
				_document.Translator = new Translator.WebApiTranslator(Settings.Default.WebApiUrl);
			}
			else
			{
				_document.Translator = new Translator.StandardTranslator();
			}
        }

		/// <summary>
		/// ユーザ設定の保存
		/// </summary>
		private void SettingSave()
		{
			var setting = Settings.Default;

			setting.WebApiFlg = uiButtonWebApi.Checked;
			setting.AutoReload = uiButtonMonitor.Checked;

			setting.WindowState = WindowState;

			if (setting.WindowState == FormWindowState.Normal)
			{
				setting.WindowBounds = Bounds;
			}
			else
			{
				setting.WindowBounds = RestoreBounds;
			}

			setting.Save();
		}

		/// <summary>
		/// ウィンドウの表示位置を画面内に収まるように調整
		/// </summary>
		/// <param name="bounds"></param>
		/// <returns></returns>
		private Rectangle AdjustmentWindowBounds(Rectangle bounds)
		{
			var workarea = Screen.FromRectangle(bounds).WorkingArea;

			if (workarea.Contains(bounds) == false)
			{
				if (bounds.Width > workarea.Width)
				{
					bounds.Width = workarea.Width;
				}
				
				if (bounds.Height > workarea.Height)
				{
					bounds.Height = workarea.Height;
				}
				
				if (bounds.Right > workarea.Right)
				{
					bounds.Offset(workarea.Right - bounds.Right, 0);
				}
				
				if (bounds.Bottom > workarea.Bottom)
				{
					bounds.Offset(0, workarea.Bottom - bounds.Bottom);
				}
				
				if (bounds.Left < workarea.Left)
				{
					bounds.Offset(workarea.Left - bounds.Left, 0);
				}
				
				if (bounds.Top < workarea.Top)
				{
					bounds.Offset(0, workarea.Top - bounds.Top);
				}
			}

			return bounds;
		}

		/// <summary>
		/// ドラッグアンドドロップ 開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// ドラッグアンドドロップ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			string[] list = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			if (list.Length > 0)
			{
				try
				{
					_document.Open(list[0]);
				}
				catch (Exception ex)
				{
					ShowException(ex);
				}
			}
		}

		/// <summary>
		/// ブラウザ ナビゲート開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "about")
			{
				// DocumentText への書き込みやページ内リンク
				Debug.WriteLine("about ... " + e.Url.OriginalString);
				return;
			}

			// その他はナビゲーションをキャンセル
			e.Cancel = true;

			try
			{
				if (e.Url.Scheme == "file")
				{
					// ローカルファイルはドラッグアンドドロップ
					Debug.WriteLine("drop ... " + e.Url.LocalPath);
					
					_document.Open(e.Url.LocalPath);
				}
				else
				{
					// その他はブラウザ起動
					Debug.WriteLine("start ... " + e.Url.AbsoluteUri);
					Process.Start(e.Url.AbsoluteUri);
				}
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

        /// <summary>
        /// ブラウザ ドキュメントコンプリート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			uiWebBrowser.Document.Body.InnerHtml = _document.GetInnerHtml();
        }

        /// <summary>
        /// ドキュメント Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Document_Opened(object sender, EventArgs e)
		{
			uiWebBrowser.DocumentText = _document.GetContainerHtml();
			UpdateControlState();
        }

        /// <summary>
        /// ドキュメント Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Document_Closed(object sender, EventArgs e)
        {
			uiWebBrowser.DocumentText = _document.GetContainerHtml();
			UpdateControlState();
        }

        /// <summary>
        /// ドキュメント Updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Document_Updated(object sender, EventArgs e)
		{
			if (uiButtonMonitor.Checked)
			{
				try
				{
					_document.Reload();

					if (uiWebBrowser.Document != null && uiWebBrowser.Document.Body != null)
					{
						uiWebBrowser.Document.Body.InnerHtml = _document.GetInnerHtml();
					}
				}
				catch (IOException)
				{
					// TODO: タイミングによっては書き込みの排他制御と競合することがあるので問答無用で閉じるのはどうか
					// とりあえず握りつぶすことにします
				}
				catch (Exception ex)
				{
					_document.Close();
					ShowException(ex);
				}
			}
        }

        /// <summary>
        /// コントロール状態の更新
        /// </summary>
        private void UpdateControlState()
        {
            if (_document.IsOpen())
            {
                // タイトルバー ... <filename> - <appname>
                Text = string.Format("{0} - {1}", _document.GetFilename(), Application.ProductName);
            }
            else
            {
                // タイトルバー ... <appname>
                Text = Application.ProductName;
            }

			// メニューバー
			uiMenuExport.Enabled = _document.IsOpen();
			uiMenuReload.Enabled = _document.IsOpen();
			uiMenuExecute.Enabled = _document.IsOpen();
			uiMenuBrowser.Enabled = _document.IsOpen();

			// ツールバー
            uiButtonExport.Enabled = _document.IsOpen();
            uiButtonReload.Enabled = _document.IsOpen();
			uiButtonExecute.Enabled = _document.IsOpen();
            uiButtonBrowser.Enabled = _document.IsOpen();
			uiButtonWebApi.Enabled = Settings.Default.WebApiUrl.Length > 0;
        }
        
        /// <summary>
        /// 例外の簡易表示
        /// </summary>
		/// <param name="ex"></param>
		private void ShowException(Exception ex)
        {
			Program.ShowException(ex);
		}

		/// <summary>
		/// コマンド 自動リロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuMonitor_Click(object sender, EventArgs e)
		{
			bool flg;

			if (sender is ToolStripMenuItem)
			{
				flg = (sender as ToolStripMenuItem).Checked;

			}
			else if (sender is ToolStripButton)
			{
				flg = (sender as ToolStripButton).Checked;
			}
			else
			{
				return;
			}

			if (uiButtonMonitor.Checked != flg)
			{
				uiButtonMonitor.Checked = flg;
			}

			if (uiMenuMonitor.Checked != flg)
			{
				uiMenuMonitor.Checked = flg;
			}
		}

		/// <summary>
		/// コマンド エクスポート
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuExport_Click(object sender, EventArgs e)
		{
			Debug.Assert(_document.IsOpen());

			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				string path = _document.GetFilename();

				dialog.AddExtension = true;
				dialog.DefaultExt = "html";
				dialog.Filter = "html file (*.html)|*.html";
				dialog.FileName = Path.GetFileName(Path.ChangeExtension(path, "html"));
				dialog.InitialDirectory = Path.GetDirectoryName(path);
				dialog.ValidateNames = true;
				dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					string html = _document.GetCombineHtml();

					try
					{
						using (var stream = dialog.OpenFile())
						{
							using (var writer = new StreamWriter(stream))
							{
								writer.Write(html);
							}
						}
					}
					catch (Exception ex)
					{
						ShowException(ex);
					}
				}
			}
		}

		/// <summary>
		/// コマンド リロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuReload_Click(object sender, EventArgs e)
		{
			Debug.Assert(_document.IsOpen());

			try
			{
				_document.Reload();
				uiWebBrowser.DocumentText = _document.GetContainerHtml();
			}
			catch (Exception ex)
			{
				_document.Close();
				ShowException(ex);
			}
		}

		/// <summary>
		/// コマンド 関連付け起動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuExecute_Click(object sender, EventArgs e)
		{
			Debug.Assert(_document.IsOpen());

			try
			{
				Process.Start(_document.GetFilename());
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

		/// <summary>
		/// コマンド ブラウザ起動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuBrowser_Click(object sender, EventArgs e)
		{
			Debug.Assert(_document.IsOpen());

			string tmp = Path.GetTempPath();

			try
			{
				tmp = _document.ExportTempFile(tmp);
				Process.Start(new Uri(tmp).AbsoluteUri);
			}
			catch (Exception ex)
			{
				ShowException(ex);
			}
		}

        /// <summary>
        /// コマンド WebApiSet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiMenuWebApiSet_Click(object sender, EventArgs e)
        {
            using (var box = new InputUrlBox())
            {
				box.Url = Settings.Default.WebApiUrl;

				if (box.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					Settings.Default.WebApiUrl = box.Url;
					UpdateControlState();
				}
            }
        }

		/// <summary>
		/// コマンド 終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// コマンド AboutBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiMenuAbout_Click(object sender, EventArgs e)
		{
			using (var box = new AboutBox())
			{
				box.ShowDialog();
			}
        }

		/// <summary>
		/// コマンド WebApiCheck
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiButtonWebApi_Click(object sender, EventArgs e)
		{
			if (uiButtonWebApi.Checked)
			{
				_document.Translator = new Translator.WebApiTranslator(Settings.Default.WebApiUrl);
			}
			else
			{
				_document.Translator = new Translator.StandardTranslator();
			}
		}
    }
}
