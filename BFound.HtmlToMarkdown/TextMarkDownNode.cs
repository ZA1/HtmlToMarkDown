using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class TextMarkDownNode : MarkDownNode
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
