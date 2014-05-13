using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class BlockquoteMarkDownNode : MarkDownNode
    {
        public override string ToString()
        {
            var line = NewLine() + base.ToString().TrimStart() + base.NewLine();
            return line;
        }

        public override string NewLine()
        {
            return base.NewLine() + "> ";
        }
    }
}
