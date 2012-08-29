using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace MarkdownView
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
				Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
				Application.Run(new FormMain());
            }
			catch (Exception ex)
			{
				ShowException(ex);
            }
        }

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			ShowException(e.Exception);
		}

		public static void ShowException(Exception ex)
		{
			using (var box = new AboutBox())
			{
				MessageBox.Show(ex.Message, box.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
    }
}
