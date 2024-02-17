namespace Desafio.Senha.Core.Rules
{
    public class PasswordRuleChainFactory
    {
        public IPasswordRuleHandler CreateChain(IEnumerable<IPasswordRuleHandler> ruleHandlers) 
        {
           
            IPasswordRuleHandler pre = ruleHandlers.First();
            IPasswordRuleHandler last = null;

            foreach (var handler in ruleHandlers.Skip(1))
            {
                pre.SetNext(handler);
                last = handler;
                pre = handler;
            }
            //last.SetNext(ruleHandlers[0]);

            return ruleHandlers.First();
        }
    }
}
