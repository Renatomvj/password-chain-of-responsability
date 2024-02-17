namespace Desafio.Senha.Core.Rules
{
    public class PasswordMustContainAtLeastOneSpecialCharacter : AbstracPasswordRuleHandler
    {
        public override object Handle(object request)
        {
            var value = (string)request;

            if (!value.Any(char.IsLetterOrDigit))
                throw new Exception("A senha deve conter pelo menos um caractere especial (!@#$%^&*()-+)");

            return base.Handle(request);
        }

        public override string RuleName()
        {
            return nameof(PasswordMustContainAtLeastOneSpecialCharacter);
        }
    }
}
