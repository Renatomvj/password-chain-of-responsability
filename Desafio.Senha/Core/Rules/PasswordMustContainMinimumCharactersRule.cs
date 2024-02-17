namespace Desafio.Senha.Core.Rules
{
    public class PasswordMustContainMinimumCharactersRule : AbstracPasswordRuleHandler
    {
        public override object Handle(object request)
        {
            var value = (string)request;

            if (!(value.Length > 8))
                throw new Exception("A senha deve conter, no mínimo, 9 caracteres");

            return base.Handle(request);
        }

        public override string RuleName()
        {
            return nameof(PasswordMustContainMinimumCharactersRule);
        }
    }
}

