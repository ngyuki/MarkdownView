using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkdownView.Translator
{
	class StandardTranslator : TranslatorInterface
	{
		public string Transform(string input)
		{
			var md = new MarkdownSharp.Markdown();
			return md.Transform(input);

			//var md = new anrControls.Markdown();
			//return md.Transform(input);
		}

		public string CustomCssFilename
		{
			get
			{
				return "css/style.css";
			}
		}

		public string DefaultCssFilename
		{
			get
			{
				return "css/style.default.css";
			}
		}
	}
}
