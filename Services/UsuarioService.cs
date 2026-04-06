namespace Biblioteca_libros
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            Console.WriteLine($">> Usuario '{usuario.Nombre} {usuario.Apellido}' agregado correctamente.");
        }

        public void EliminarUsuario(string idDocumento)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].IdDocumento == idDocumento)
                {
                    Console.WriteLine($">> Usuario '{usuarios[i].Nombre} {usuarios[i].Apellido}' eliminado correctamente.");
                    usuarios.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($">> No se encontró un usuario con ID/Documento '{idDocumento}'.");
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        public bool ActualizarUsuario(Usuario usuarioActualizado)
        {
            Usuario? existente = ObtenerPorDocumento(usuarioActualizado.IdDocumento);
            if (existente is null)
            {
                return false;
            }

            existente.Nombre = usuarioActualizado.Nombre;
            existente.Apellido = usuarioActualizado.Apellido;
            existente.CorreoElectronico = usuarioActualizado.CorreoElectronico;
            existente.TelefonoContacto = usuarioActualizado.TelefonoContacto;
            existente.Activo = usuarioActualizado.Activo;
            return true;
        }


        public void ListarUsuarios()
        {
            Console.WriteLine(">> Lista de Usuarios:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
        }

        public Usuario? ObtenerPorDocumento(string idDocumento)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.IdDocumento == idDocumento)
                {
                    return usuario;
                }
            }
            return null;
        }

        public void BuscarPorNombre(string nombre)
        {
            Console.WriteLine($">> Resultados de búsqueda para nombre '{nombre}':");
            bool encontrado = false;
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(usuario.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine(">> No se encontraron usuarios con ese nombre.");
            }
        }

        public void OrdenarPorNombre()
        {
            usuarios.Sort((u1, u2) => string.Compare(u1.Nombre, u2.Nombre, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(">> Usuarios ordenados por nombre.");
        }
    }
}