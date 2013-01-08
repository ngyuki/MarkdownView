using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

namespace MarkdownView.Translator
{
	class WebApiTranslator : TranslatorInterface
	{
		public string Transform(string input)
		{
			try
			{
				WebClient wc = new WebClient();
				
				wc.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
				
				string url = @"http://redcarpet-preview.herokuapp.com/markdown/raw";

				byte[] bytes = wc.UploadData(url, Encoding.UTF8.GetBytes(input));

				return Encoding.UTF8.GetString(bytes);
			}
			catch (Exception ex)
			{
				string html = System.Web.HttpUtility.HtmlEncode(ex.ToString());
				return "<div style=\"white-space:pre;margin:20px\">" + html + "</div>";
			}
		}

		public string CustomCssFilename
		{
			get
			{
				return "css/webapi.css";
			}
		}

		public string DefaultCssFilename
		{
			get
			{
				return "css/webapi.default.css";
			}
		}
	}
}
