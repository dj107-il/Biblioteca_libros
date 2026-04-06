namespace Biblioteca_libros
{
    public class LibroServices
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine($">> Libro '{libro.Titulo}' agregado correctamente.");

        }

        public void EliminarLibro(string idIsbn)
        {
            for (int i = 0; i < libros.Count; i++)
            {
                if (libros[i].IdIsbn == idIsbn)
                {
                    Console.WriteLine($">> Libro '{libros[i].Titulo}' eliminado correctamente.");
                    libros.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($">> No se encontró un libro con ISBN '{idIsbn}'.");
        }

        public void ListarLibros()
        {
            Console.WriteLine(">> Lista de Libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro.ToString());
            }
        }

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        public Libro? ObtenerPorIsbn(string idIsbn)
        {
            foreach (Libro libro in libros)
            {
                if (libro.IdIsbn == idIsbn)
                {
                    return libro;
                }
            }
            return null;
        }

        public void BuscarPorTitulo(string titulo)
        {
            Console.WriteLine($">> Resultados de búsqueda para título '{titulo}':");
            bool encontrado = false;
            foreach (Libro libro in libros)
            {
                if (libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(libro.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine(">> No se encontraron libros con ese título.");
        }

        public void BuscarPorAutor(string autor)
        {
            Console.WriteLine($">> Resultados de búsqueda para autor '{autor}':");
            bool encontrado = false;
            foreach (Libro libro in libros)
            {
                if (libro.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(libro.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine(">> No se encontraron libros de ese autor.");
        }

        public void OrdenarPorTitulo()
        {
            libros = libros.OrderBy(l => l.Titulo).ToList();
            Console.WriteLine(">> Libros ordenados por título.");
        }

        public void OrdenarPorAño()
        {
            libros = libros.OrderBy(l => l.AñoPublicacion).ToList();
            Console.WriteLine(">> Libros ordenados por año de publicación.");
        }

        public int TotalLibros()
        {
            return libros.Count;
        }

        public void LibrosDisponibles()
        {
            Console.WriteLine(">> Libros disponibles:");
            bool encontrado = false;
            foreach (Libro libro in libros)
            {
                if (libro.Disponible)
                {
                    Console.WriteLine(libro.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine(">> No hay libros disponibles en este momento.");
        }

        public void LibrosPrestados()
        {
            Console.WriteLine(">> Libros prestados:");
            bool encontrado = false;
            foreach (Libro libro in libros)
            {
                if (!libro.Disponible)
                {
                    Console.WriteLine(libro.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine(">> No hay libros prestados en este momento.");
        }
    }
}