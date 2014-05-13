using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class ImageMarkDownNode : MarkDownNode
    {
        public string Src { get; set; }

        public string Alt { get; set; }

        public override string ToString()
        {
            return "![" + Alt + "](" + Src + ")";
        }
    }
}
