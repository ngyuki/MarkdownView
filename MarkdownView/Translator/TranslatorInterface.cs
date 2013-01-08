using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkdownView.Translator
{
	interface TranslatorInterface
	{
		string Transform(string input);
		string CustomCssFilename { get; }
		string DefaultCssFilename { get; }
	}
}
