using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ColorCode;

namespace MarkdownView.Translator
{
	class StandardTranslator : TranslatorInterface
	{
        private MarkdownSharp.Markdown _markdownParser;
        
        private CodeColorizer _codeColorizer;
        
        private Regex _codeBlockRegex;
        
        private Dictionary<string, ILanguage> _mapLanguage = new Dictionary<string, ILanguage> {
            { "js", Languages.JavaScript },
            { "cs", Languages.CSharp },
        };
        
        public StandardTranslator()
        {
            const string pattern = @"^\s*```\s*(\S*)\s*^(.*?)$\s*```\s*$";
            
            _markdownParser = new MarkdownSharp.Markdown();
            
            _codeColorizer = new CodeColorizer();
            
            _codeBlockRegex = new Regex(
                pattern,
                RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.Compiled
            );
        }
        
        private ILanguage LookupLanguage(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return null;
            }
            
            lang = lang.ToLower();
            lang = Regex.Replace(lang, ":.*$", "");
            
            if (_mapLanguage.ContainsKey(lang))
            {
                return _mapLanguage[lang];
            }
            
            return Languages.FindById(lang);
        }
        
        private string SyntaxHighlight(string input, string lang)
        {
            var language = LookupLanguage(lang);
            
            if (language != null)
            {
                return _codeColorizer.Colorize(input, language);
            }
            else
            {
                return "<pre>" + HttpUtility.HtmlEncode(input) + "</pre>";
            }
        }
        
        public string Transform(string input)
        {
            input = _codeBlockRegex.Replace(input, m => SyntaxHighlight(m.Groups[2].Value, m.Groups[1].Value));
            return _markdownParser.Transform(input);
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
