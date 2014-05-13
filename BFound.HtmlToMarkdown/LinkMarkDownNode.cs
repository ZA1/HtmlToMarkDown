using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class LinkMarkDownNode : MarkDownNode
    {
        public string Href { get; set; }

        public override string ToString()
        {
            return "[" + base.ToString() + "](" + Href + ")";
        }
    }
}
