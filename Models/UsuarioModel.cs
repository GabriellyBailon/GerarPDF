using System.ComponentModel.DataAnnotations;

namespace GerarPDF.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public UsuarioModel(){ }

        public UsuarioModel(string nome, string email, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Nome = nome;
            Email = email;
        }
    }
}
