using GerarPDF.Interfaces;
using GerarPDF.Models;
using GerarPDF.Utils;

namespace GerarPDF.Services
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService() { }

        private List<UsuarioModel> Usuarios = new()
        {
            new UsuarioModel("João Silva", "user1@gmail.com.br", Guid.NewGuid()),
            new UsuarioModel("Marcos Palmeira", "user2@gmail.com.br", Guid.NewGuid()),
            new UsuarioModel("Givanildo", "user3@gmail.com.br", Guid.NewGuid()),
            new UsuarioModel("Mark Ruffalo", "user4@gmail.com.br", Guid.NewGuid()),
            new UsuarioModel("Robert Downey Júnior", "user5@gmail.com.br", Guid.NewGuid())
        };

        public byte[] GerarPDF()
        {
            var pdfBytes = PDFUtils.GerarPDF(Usuarios);

            return pdfBytes;
        }

        public void AdicionarUsuario(UsuarioModel usuario)
        {
            ValidarUsuario(usuario);

            Usuarios.Add(usuario);
        }

        #region Métodos Auxiliares

        private static void ValidarUsuario(UsuarioModel usuario)
        {
            if (usuario == null)
                throw new ArgumentException("Usuário não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ArgumentException("Nome do usuário não pode ser nulo ou vazio.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("Email do usuário não pode ser nulo ou vazio.");
        }

        #endregion Métodos Auxiliares
    }
}
