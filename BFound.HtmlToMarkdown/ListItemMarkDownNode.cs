using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class ListItemMarkDownNode : MarkDownNode
    {
        public override string ToString()
        {
            if (Parent is OrderdListMarkDownNode)
            {
                var index = Parent.ChildNodes.IndexOf(this) + 1;
                return base.NewLine() + index + ". " + base.ToString().TrimStart();
            }
            return base.NewLine() + "* " + base.ToString().TrimStart();
        }

        public override string NewLine()
        {
            if (Parent is OrderdListMarkDownNode)
            {
                return base.NewLine() + "   ";
            }
            return base.NewLine() + "  ";
        }
    }
}
