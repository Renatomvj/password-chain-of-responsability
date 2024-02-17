namespace Desafio.Senha.Core
{
    public class PasswordService : IPasswordService
    {
        public readonly IPasswordValidator _passwordValidator;
        public PasswordService(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        
        }
        public bool Validator(string value)
        {
            return _passwordValidator.Validate(value);
        }
    }
}
