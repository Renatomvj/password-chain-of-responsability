﻿namespace Desafio.Senha.Core.Rules
{
    public class PasswordMustContainAtLeastOneDigitRule : AbstracPasswordRuleHandler
    {
        public override object Handle(object request)
        {
            var value = (string)request;

            if (!value.Any(char.IsUpper))
                throw new Exception("A senha deve conter ao menos uma letra maiúscula");
            return base.Handle(request);
        }

        public override string RuleName()
        {
            return nameof(PasswordMustContainAtLeastOneDigitRule);
        }
    }
}
