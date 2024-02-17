namespace Desafio.Senha.Core.Rules
{
    public class PasswordMustNotContainRepeatedCharacters : AbstracPasswordRuleHandler
    {
        public override object Handle(object request)
        {
            var value = (string)request;

            if (RepeatedCharacters(value))
                return "A senha não deve possuir caracteres repetidos";

            return base.Handle(request);
        }

        public override string RuleName()
        {
            return nameof(PasswordMustNotContainRepeatedCharacters);
        }

        private bool RepeatedCharacters(string value)
        {
            var auxValue = value;
            for (int i = 0; i < value.Length; i++)
            {
                var character = value[i];
                var characterRemoved = auxValue.Remove(i, 1);

                if (characterRemoved.Contains(character))
                    return true;
            }
            return false;
        }
    }
}
