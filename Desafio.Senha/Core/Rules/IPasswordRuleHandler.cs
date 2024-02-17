namespace Desafio.Senha.Core.Rules
{
    public interface IPasswordRuleHandler
    {
        IPasswordRuleHandler SetNext(IPasswordRuleHandler next);
        object Handle(object request);
    }
}
