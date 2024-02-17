using Desafio.Senha.Core.Rules;
using Desafio.Senha.Core.Constants;
using Microsoft.Extensions.Options;

namespace Desafio.Senha.Core
{

    public class PasswordValidator : IPasswordValidator
    {
        private readonly IPasswordRuleHandler _passwordRules;
        public PasswordValidator(PasswordRuleChainFactory passwordRuleChainFactory,
            [FromKeyedServices(Constants.Constants.PasswordRules)] IEnumerable<IPasswordRuleHandler> passwordRules, IOptions<AppsettingsRulesOptions> rulesSettings)
        {          

            _passwordRules = passwordRuleChainFactory.CreateChain(OrganizeRules(passwordRules, rulesSettings));           
        }

        public bool Validate(string value)
        {
            var result = _passwordRules.Handle(value);

            return result != null;
        }

        private IEnumerable<IPasswordRuleHandler> OrganizeRules (IEnumerable<IPasswordRuleHandler> passwordRules, IOptions<AppsettingsRulesOptions> rulesSettings) 
        {
            List<IPasswordRuleHandler> orderedPasswordRuleHandlers = new List<IPasswordRuleHandler>();

            var passwordRulesDictionary = passwordRules.ToDictionary(x => x.RuleName(), x => x);
            var orderedRules = rulesSettings.Value.Rules.OrderBy(x => x.Position).ToList();


            foreach (var rule in orderedRules)
            {
                orderedPasswordRuleHandlers.Add(passwordRulesDictionary[rule.Description]);
            }
            

            return orderedPasswordRuleHandlers;
        }

    }
}
