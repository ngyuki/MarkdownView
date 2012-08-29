namespace MarkdownView
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.uiToolStrip = new System.Windows.Forms.ToolStrip();
			this.uiButtonMonitor = new System.Windows.Forms.ToolStripButton();
			this.uiButtonReload = new System.Windows.Forms.ToolStripButton();
			this.uiButtonExport = new System.Windows.Forms.ToolStripButton();
			this.uiButtonExecute = new System.Windows.Forms.ToolStripButton();
			this.uiButtonBrowser = new System.Windows.Forms.ToolStripButton();
			this.uiButtonAbout = new System.Windows.Forms.ToolStripButton();
			this.uiWebBrowser = new System.Windows.Forms.WebBrowser();
			this.uiMenuStrip = new System.Windows.Forms.MenuStrip();
			this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuMonitor = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuReload = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuExecute = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuBrowser = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.uiMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uiMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.uiToolStrip.SuspendLayout();
			this.uiMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// uiToolStrip
			// 
			this.uiToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiButtonMonitor,
            this.uiButtonReload,
            this.uiButtonExport,
            this.uiButtonExecute,
            this.uiButtonBrowser,
            this.uiButtonAbout});
			this.uiToolStrip.Location = new System.Drawing.Point(0, 26);
			this.uiToolStrip.Name = "uiToolStrip";
			this.uiToolStrip.Size = new System.Drawing.Size(747, 25);
			this.uiToolStrip.TabIndex = 1;
			this.uiToolStrip.Text = "toolStrip1";
			// 
			// uiButtonMonitor
			// 
			this.uiButtonMonitor.Checked = true;
			this.uiButtonMonitor.CheckOnClick = true;
			this.uiButtonMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiButtonMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonMonitor.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonMonitor.Image")));
			this.uiButtonMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonMonitor.Name = "uiButtonMonitor";
			this.uiButtonMonitor.Size = new System.Drawing.Size(23, 22);
			this.uiButtonMonitor.Text = "自動リロード";
			this.uiButtonMonitor.Click += new System.EventHandler(this.uiMenuMonitor_Click);
			// 
			// uiButtonReload
			// 
			this.uiButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonReload.Image")));
			this.uiButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonReload.Name = "uiButtonReload";
			this.uiButtonReload.Size = new System.Drawing.Size(23, 22);
			this.uiButtonReload.Text = "リロード";
			this.uiButtonReload.Click += new System.EventHandler(this.uiMenuReload_Click);
			// 
			// uiButtonExport
			// 
			this.uiButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonExport.Image")));
			this.uiButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonExport.Name = "uiButtonExport";
			this.uiButtonExport.Size = new System.Drawing.Size(23, 22);
			this.uiButtonExport.Text = "エクスポート";
			this.uiButtonExport.Click += new System.EventHandler(this.uiMenuExport_Click);
			// 
			// uiButtonExecute
			// 
			this.uiButtonExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonExecute.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonExecute.Image")));
			this.uiButtonExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonExecute.Name = "uiButtonExecute";
			this.uiButtonExecute.Size = new System.Drawing.Size(23, 22);
			this.uiButtonExecute.Text = "関連付けで開く";
			this.uiButtonExecute.Click += new System.EventHandler(this.uiMenuExecute_Click);
			// 
			// uiButtonBrowser
			// 
			this.uiButtonBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonBrowser.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonBrowser.Image")));
			this.uiButtonBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonBrowser.Name = "uiButtonBrowser";
			this.uiButtonBrowser.Size = new System.Drawing.Size(23, 22);
			this.uiButtonBrowser.Text = "ブラウザで開く";
			this.uiButtonBrowser.Click += new System.EventHandler(this.uiMenuBrowser_Click);
			// 
			// uiButtonAbout
			// 
			this.uiButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uiButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("uiButtonAbout.Image")));
			this.uiButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiButtonAbout.Name = "uiButtonAbout";
			this.uiButtonAbout.Size = new System.Drawing.Size(23, 22);
			this.uiButtonAbout.Text = "バージョン情報";
			this.uiButtonAbout.Click += new System.EventHandler(this.uiMenuAbout_Click);
			// 
			// uiWebBrowser
			// 
			this.uiWebBrowser.Location = new System.Drawing.Point(423, 230);
			this.uiWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.uiWebBrowser.Name = "uiWebBrowser";
			this.uiWebBrowser.Size = new System.Drawing.Size(159, 91);
			this.uiWebBrowser.TabIndex = 2;
			this.uiWebBrowser.WebBrowserShortcutsEnabled = false;
			this.uiWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.uiWebBrowser_DocumentCompleted);
			this.uiWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.uiWebBrowser_Navigating);
			// 
			// uiMenuStrip
			// 
			this.uiMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
			this.uiMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.uiMenuStrip.Name = "uiMenuStrip";
			this.uiMenuStrip.Size = new System.Drawing.Size(747, 26);
			this.uiMenuStrip.TabIndex = 3;
			this.uiMenuStrip.Text = "menuStrip1";
			// 
			// ファイルToolStripMenuItem
			// 
			this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiMenuMonitor,
            this.uiMenuExport,
            this.uiMenuReload,
            this.uiMenuExecute,
            this.uiMenuBrowser,
            this.toolStripSeparator1,
            this.uiMenuExit});
			this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
			this.ファイルToolStripMenuItem.Text = "ファイル";
			// 
			// uiMenuMonitor
			// 
			this.uiMenuMonitor.Checked = true;
			this.uiMenuMonitor.CheckOnClick = true;
			this.uiMenuMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiMenuMonitor.Name = "uiMenuMonitor";
			this.uiMenuMonitor.Size = new System.Drawing.Size(160, 22);
			this.uiMenuMonitor.Text = "自動リロード";
			this.uiMenuMonitor.Click += new System.EventHandler(this.uiMenuMonitor_Click);
			// 
			// uiMenuExport
			// 
			this.uiMenuExport.Name = "uiMenuExport";
			this.uiMenuExport.Size = new System.Drawing.Size(160, 22);
			this.uiMenuExport.Text = "エクスポート";
			this.uiMenuExport.Click += new System.EventHandler(this.uiMenuExport_Click);
			// 
			// uiMenuReload
			// 
			this.uiMenuReload.Name = "uiMenuReload";
			this.uiMenuReload.Size = new System.Drawing.Size(160, 22);
			this.uiMenuReload.Text = "リロード";
			this.uiMenuReload.Click += new System.EventHandler(this.uiMenuReload_Click);
			// 
			// uiMenuExecute
			// 
			this.uiMenuExecute.Name = "uiMenuExecute";
			this.uiMenuExecute.Size = new System.Drawing.Size(160, 22);
			this.uiMenuExecute.Text = "関連付けで開く";
			this.uiMenuExecute.Click += new System.EventHandler(this.uiMenuExecute_Click);
			// 
			// uiMenuBrowser
			// 
			this.uiMenuBrowser.Name = "uiMenuBrowser";
			this.uiMenuBrowser.Size = new System.Drawing.Size(160, 22);
			this.uiMenuBrowser.Text = "ブラウザで表示";
			this.uiMenuBrowser.Click += new System.EventHandler(this.uiMenuBrowser_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
			// 
			// uiMenuExit
			// 
			this.uiMenuExit.Name = "uiMenuExit";
			this.uiMenuExit.Size = new System.Drawing.Size(160, 22);
			this.uiMenuExit.Text = "終了";
			this.uiMenuExit.Click += new System.EventHandler(this.uiMenuExit_Click);
			// 
			// ヘルプToolStripMenuItem
			// 
			this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiMenuAbout});
			this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
			this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
			this.ヘルプToolStripMenuItem.Text = "ヘルプ";
			// 
			// uiMenuAbout
			// 
			this.uiMenuAbout.Name = "uiMenuAbout";
			this.uiMenuAbout.Size = new System.Drawing.Size(160, 22);
			this.uiMenuAbout.Text = "バージョン情報";
			this.uiMenuAbout.Click += new System.EventHandler(this.uiMenuAbout_Click);
			// 
			// FormMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 425);
			this.Controls.Add(this.uiWebBrowser);
			this.Controls.Add(this.uiToolStrip);
			this.Controls.Add(this.uiMenuStrip);
			this.MainMenuStrip = this.uiMenuStrip;
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			this.uiToolStrip.ResumeLayout(false);
			this.uiToolStrip.PerformLayout();
			this.uiMenuStrip.ResumeLayout(false);
			this.uiMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uiToolStrip;
        private System.Windows.Forms.ToolStripButton uiButtonMonitor;
        private System.Windows.Forms.WebBrowser uiWebBrowser;
        private System.Windows.Forms.ToolStripButton uiButtonExport;
        private System.Windows.Forms.ToolStripButton uiButtonReload;
        private System.Windows.Forms.ToolStripButton uiButtonBrowser;
        private System.Windows.Forms.ToolStripButton uiButtonAbout;
		private System.Windows.Forms.MenuStrip uiMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uiMenuMonitor;
		private System.Windows.Forms.ToolStripMenuItem uiMenuExport;
		private System.Windows.Forms.ToolStripMenuItem uiMenuReload;
		private System.Windows.Forms.ToolStripMenuItem uiMenuBrowser;
		private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uiMenuAbout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem uiMenuExit;
		private System.Windows.Forms.ToolStripButton uiButtonExecute;
		private System.Windows.Forms.ToolStripMenuItem uiMenuExecute;

    }
}

