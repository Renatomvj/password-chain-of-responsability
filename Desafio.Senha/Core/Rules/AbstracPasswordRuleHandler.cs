namespace Desafio.Senha.Core.Rules
{
    public abstract class AbstracPasswordRuleHandler : IPasswordRuleHandler
    {
        private IPasswordRuleHandler _nextHandler;
        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

        public abstract string RuleName();
        

        public IPasswordRuleHandler SetNext(IPasswordRuleHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;          
        }
    }
}
