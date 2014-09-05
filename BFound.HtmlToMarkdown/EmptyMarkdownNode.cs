using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class EmptyMarkdownNode: MarkDownNode
    {
        public override string ToString()
        {
            return "";
        }
    }
}
