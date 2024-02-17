namespace Desafio.Senha.Core
{
    public interface IPasswordValidator
    {
        bool Validate(string password);
    }
}