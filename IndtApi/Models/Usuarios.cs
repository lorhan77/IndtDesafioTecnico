using IndtApi.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace IndtApi.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Usuarios_CorrigindoAtributos]
        public string Nome { get; set; }
        public string? Sobrenome { get; set;}

        public string?Email { get; set;}

        public string? Senha { get; set; }

        [Usuarios_CorrigindoAtributos]
        public string NivelDeAcesso { get; set; }
    }
}
