using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Interfaces.Rules
{
    public interface IContentRule
    {
        bool CheckRule(string content);
    }
}
