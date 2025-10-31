using GerarPDF.Interfaces;
using GerarPDF.Models;
using GerarPDF.Services;
using GerarPDF.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GerarPDF.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost("criarUsuario")]
        public IActionResult CriarUsuario([FromBody] UsuarioModel usuario)
        {
            _logger.LogInformation("Criando um novo usuário.");

            _usuarioService.AdicionarUsuario(usuario);

            return Ok();
        }

      [HttpGet("obterUsuarios")] 
      public IActionResult ObterUsuario()
      {
          _logger.LogInformation("Obtendo os usuários");
          return Ok();
      }

      [HttpGet("obterPDF")]
      public IActionResult ObterPDF()
      {
          _logger.LogInformation("Salvando PDF");
          var pdfBytes = _usuarioService.GerarPDF();

          return File(pdfBytes, "application/octet-stream", $"Relatório de Usuários {DateTime.Now:yyyyMMdd_HHmm}.pdf");
      }
    }
}
