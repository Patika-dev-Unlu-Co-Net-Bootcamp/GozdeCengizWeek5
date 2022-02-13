using BlogProject.Application.Interfaces.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Extension.Rules
{
    public class TitleLengthRule : ITitleRule
    {
        public bool CheckRule(string title)
        {
            int length = title.Length;

            if (length < 5)
            {
                return false;
            }
            else if (length > 15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
