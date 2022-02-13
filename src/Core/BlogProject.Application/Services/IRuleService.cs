using BlogProject.Application.Interfaces.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services
{
    public interface IRuleService
    {
        List<ITitleRule> GetTitleRules();
    }
}
