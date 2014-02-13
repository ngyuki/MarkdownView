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
                SettingUpgrade();
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        static void SettingUpgrade()
        {
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
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
