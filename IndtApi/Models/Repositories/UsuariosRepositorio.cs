namespace IndtApi.Models.Repositories
{
    public static class UsuariosRepositorio
    {
        private static List<Usuarios> usuarios = new List<Usuarios>()
        {
            new Usuarios{Id = 1, Nome="aaaaaa", Sobrenome="bbbbbbbbb", Email="aaaaaa@gmail.com", Senha="12312", NivelDeAcesso="Administrador"},
            new Usuarios{Id = 2, Nome="bbbbbb", Sobrenome="ccccccccc", Email="bbbbbb@gmail.com", Senha="45678", NivelDeAcesso="Comum"},
            new Usuarios{Id = 3, Nome="cccccc", Sobrenome="ddddddddd", Email="cccccc@gmail.com", Senha="23123", NivelDeAcesso="Comum"},
            new Usuarios{Id = 4, Nome="dddddd", Sobrenome="eeeeeeeee", Email="dddddd@gmail.com", Senha="21312", NivelDeAcesso="Comum"}
        };

        public static List<Usuarios> GetUsuarios()
        {
            return usuarios;
        }
        public static bool UsuariosExiste(int id)
        {
            return usuarios.Any(x => x.Id == id);
        }
         
        public static Usuarios? GetUsuariosById(int id)
        {
            return usuarios.FirstOrDefault(x => x.Id == id);
        }

        public static Usuarios? GetUsuariosByProperties(string? email, string? senha)
        {
            return usuarios.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(email) &&
            !string.IsNullOrWhiteSpace(x.Email) &&
            x.Email.Equals(email, StringComparison.OrdinalIgnoreCase)&& 
            !string.IsNullOrWhiteSpace(senha) &&
            !string.IsNullOrWhiteSpace(x.Senha) &&
            x.Senha.Equals(senha, StringComparison.OrdinalIgnoreCase));

        }
       public static void AddUsuarios(Usuarios usuario)
        {
            int maxId = usuarios.Max(x => x.Id);
            usuario.Id = maxId + 1;

            usuarios.Add(usuario);
        }

        public static void UpdateUsuario(Usuarios usuario)
        {
            var usuarioToUpdate = usuarios.First(x => x.Id == usuario.Id);
            usuarioToUpdate.Nome = usuario.Nome;
            usuarioToUpdate.Sobrenome = usuario.Sobrenome;
            usuarioToUpdate.Email = usuario.Email;
            usuarioToUpdate.Senha = usuario.Senha;
            usuarioToUpdate.NivelDeAcesso = usuario.NivelDeAcesso;
        }

        public static void DeleteUsuario(int id)
        {
            var usuario = GetUsuariosById(id);
            if(usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }
    }
}
