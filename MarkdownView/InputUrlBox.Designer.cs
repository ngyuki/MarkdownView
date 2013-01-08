namespace MarkdownView
{
	partial class InputUrlBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uiTextBox = new System.Windows.Forms.TextBox();
			this.uiButtonCansel = new System.Windows.Forms.Button();
			this.uiButtonOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// uiTextBox
			// 
			this.uiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uiTextBox.Location = new System.Drawing.Point(12, 11);
			this.uiTextBox.Name = "uiTextBox";
			this.uiTextBox.Size = new System.Drawing.Size(440, 19);
			this.uiTextBox.TabIndex = 0;
			// 
			// uiButtonCansel
			// 
			this.uiButtonCansel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uiButtonCansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uiButtonCansel.Location = new System.Drawing.Point(377, 44);
			this.uiButtonCansel.Name = "uiButtonCansel";
			this.uiButtonCansel.Size = new System.Drawing.Size(75, 23);
			this.uiButtonCansel.TabIndex = 1;
			this.uiButtonCansel.Text = "キャンセル";
			this.uiButtonCansel.UseVisualStyleBackColor = true;
			this.uiButtonCansel.Click += new System.EventHandler(this.uiButtonCansel_Click);
			// 
			// uiButtonOk
			// 
			this.uiButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uiButtonOk.Location = new System.Drawing.Point(296, 44);
			this.uiButtonOk.Name = "uiButtonOk";
			this.uiButtonOk.Size = new System.Drawing.Size(75, 23);
			this.uiButtonOk.TabIndex = 2;
			this.uiButtonOk.Text = "OK";
			this.uiButtonOk.UseVisualStyleBackColor = true;
			this.uiButtonOk.Click += new System.EventHandler(this.uiButtonOk_Click);
			// 
			// InputUrlBox
			// 
			this.AcceptButton = this.uiButtonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.uiButtonCansel;
			this.ClientSize = new System.Drawing.Size(464, 78);
			this.Controls.Add(this.uiButtonOk);
			this.Controls.Add(this.uiButtonCansel);
			this.Controls.Add(this.uiTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputUrlBox";
			this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "URLを入力してください";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox uiTextBox;
		private System.Windows.Forms.Button uiButtonCansel;
		private System.Windows.Forms.Button uiButtonOk;
	}
}