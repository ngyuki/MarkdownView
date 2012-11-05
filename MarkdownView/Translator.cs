using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkdownView
{
	class Translator
	{
		public string Transform(string input)
		{
			var md = new MarkdownSharp.Markdown();
			return md.Transform(input);

			//var md = new anrControls.Markdown();
			//return md.Transform(input);
		}
	}
}
