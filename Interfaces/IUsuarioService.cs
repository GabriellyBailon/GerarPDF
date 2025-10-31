using GerarPDF.Models;

namespace GerarPDF.Interfaces
{
    public interface IUsuarioService
    {
        byte[] GerarPDF();
        void AdicionarUsuario(UsuarioModel usuario);
    }
}
