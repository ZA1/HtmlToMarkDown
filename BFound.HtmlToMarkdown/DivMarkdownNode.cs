using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public class DivMarkDownNode: MarkDownNode
    {
        public override string ToString()
        {
            if(ChildNodes.Last() is BreakMarkDownNode)
            {
                return base.ToString().TrimStart();
            }
            return base.ToString().TrimStart() + "  " + NewLine();
        }
    }
}
