namespace Biblioteca_libros
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
            Console.WriteLine($">> Préstamo '{prestamo.IdPrestamo}' agregado correctamente.");
        }

        public void EliminarPrestamo(string idPrestamo)
        {
            for (int i = 0; i < prestamos.Count; i++)
            {
                if (prestamos[i].IdPrestamo == idPrestamo)
                {
                    Console.WriteLine($">> Préstamo '{prestamos[i].IdPrestamo}' eliminado correctamente.");
                    prestamos.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($">> No se encontró un préstamo con ID '{idPrestamo}'.");
        }

        public void ListarPrestamos()
        {
            Console.WriteLine(">> Lista de Préstamos:");
            foreach (var prestamo in prestamos)
            {
                Console.WriteLine(prestamo.ToString());
            }
        }

        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        public Prestamo? ObtenerPorId(string idPrestamo)
        {
            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.IdPrestamo == idPrestamo)
                {
                    return prestamo;
                }
            }
            return null;
        }

        public void BuscarPorEstado(EstadoPrestamo estado)
        {
            Console.WriteLine($">> Resultados de búsqueda para estado '{estado}':");
            bool encontrado = false;
            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == estado)
                {
                    Console.WriteLine(prestamo.ToString());
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine($">> No se encontraron préstamos con estado '{estado}'.");
            }
        }

        public void OrdenarPorFechaLimite()
        {
            prestamos.Sort((p1, p2) => p1.FechaLimite.CompareTo(p2.FechaLimite));
            Console.WriteLine(">> Préstamos ordenados por fecha límite:");
            foreach (var prestamo in prestamos)
            {
                Console.WriteLine(prestamo.ToString());
            }
        }
    }
}