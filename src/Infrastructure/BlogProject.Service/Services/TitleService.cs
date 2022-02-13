using BlogProject.Application.Interfaces.Rules;
using BlogProject.Application.Services;
using BlogProject.Service.Extension.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services
{
    public class TitleService :IRuleService
    {
        public List<ITitleRule> GetTitleRules()
        {
            ITitleRule titleRules = new FirstCharRule();
            ITitleRule titleRules1 = new TitleLengthRule();

            List<ITitleRule> titleRulesList = new();

            titleRulesList.Add(titleRules);
            titleRulesList.Add(titleRules1);

            return titleRulesList;
        }
    }
}
