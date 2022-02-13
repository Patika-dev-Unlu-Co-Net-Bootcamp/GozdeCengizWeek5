using BlogProject.Application.Interfaces.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Extension.Rules
{
    public class FirstCharRule : ITitleRule
    {
        public bool CheckRule(string title)
        {
            return true;
        }
    }
}
