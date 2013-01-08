using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkdownView
{
	public partial class InputUrlBox : Form
	{
		public InputUrlBox()
		{
			InitializeComponent();
		}

		public string Url
		{
			get
			{
				return uiTextBox.Text;
			}

			set
			{
				uiTextBox.Text = value;
			}
		}

		private void uiButtonOk_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void uiButtonCansel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
	}
}
