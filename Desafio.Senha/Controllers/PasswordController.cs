using Desafio.Senha.Core;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Senha.Controllers
{
    [ApiController]
    [Route("api/validator-password")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpPost]
        public IActionResult Validator([FromBody] string value)
        {
            _passwordService.Validator(value);

            return Ok();
        }
    }
}
