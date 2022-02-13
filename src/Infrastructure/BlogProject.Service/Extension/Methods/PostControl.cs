using BlogProject.Application.Interfaces.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Extension.Methods
{
    public static class PostControl
    {
        public static bool IsValidTitle(this string title, List<ITitleRule> rules)
        {
            foreach (var item in rules)
            {
                if (!item.CheckRule(title))
                    return false;
            }
            return true;

        }

        public static bool IsValidContent(this string content, List<IContentRule> rules)
        {
            foreach (var item in rules)
            {
                if (!item.CheckRule(content))
                    return false;
            }
            return true;
        }

    }
}
