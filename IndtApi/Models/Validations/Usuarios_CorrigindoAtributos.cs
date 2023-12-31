using System.ComponentModel.DataAnnotations;

namespace IndtApi.Models.Validations
{
    public class Usuarios_CorrigindoAtributos : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var usuarios = validationContext.ObjectInstance as Usuarios;

            if(usuarios != null)
            {
                if(usuarios.Nome == "")
                {
                    return new ValidationResult("O campo Nome não pode estar vazio");
                }else if (usuarios.Email == "")
                {
                    return new ValidationResult("O campo Email não pode estar vazio");
                }
                else if (usuarios.Senha == "")
                {
                    return new ValidationResult("O campo Senha não pode estar vazio");
                }
                else if (usuarios.NivelDeAcesso == "")
                {
                    return new ValidationResult("O campo Nível de Acesso não pode estar vazio");
                }
            }

            return ValidationResult.Success;
        }
    }
}
