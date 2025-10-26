using GerarPDF.Models;
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
        private readonly List<UsuarioModel> Usuarios = new()
        {
            new UsuarioModel(1, "João Silva", "user1@gmail.com.br"),
            new UsuarioModel(2, "Marcos Palmeira", "user2@gmail.com.br"),
            new UsuarioModel(3, "Givanildo", "user3@gmail.com.br"),
            new UsuarioModel(4, "Mark Ruffalo", "user4@gmail.com.br"),
            new UsuarioModel(5, "Robert Downey Júnior", "user5@gmail.com.br")
        };

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost("criarUsuario")] 
        public IActionResult CriarUsuario()
        {
            _logger.LogInformation("Criando um novo usuário.");
            return new OkResult();
        }

      [HttpGet("obterUsuarios")] 
      public IActionResult ObterUsuario()
      {
          _logger.LogInformation("Obtendo os usuários");
          return Ok(Usuarios);
      }

      [HttpGet("obterPDF")]
      public IActionResult ObterPDF()
      {
          _logger.LogInformation("Salvando PDF");
          var pdfBytes = PDFUtils.GerarPDF(Usuarios);

          return File(pdfBytes, "application/octet-stream", $"Relatório de Usuários {DateTime.Now:yyyyMMdd_HHmm}.pdf"); ;
      }
    }
}
