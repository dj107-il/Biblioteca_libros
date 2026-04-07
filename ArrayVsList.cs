namespace Biblioteca_libros
{
    public class ArrayVsList
    {
        public static void Comparar()
        {
            string[] coleccionInicial = new string[3];
            coleccionInicial[0] = "Cien años de soledad";
            coleccionInicial[1] = "El Principito";
            coleccionInicial[2] = "Don Quijote";

            Console.WriteLine("=== Colección Inicial ===");
            foreach (string titulo in coleccionInicial)
            {
                Console.WriteLine($"- {titulo}");
            }
            Console.WriteLine($"Total: {coleccionInicial.Length}");

            List<string> coleccionAmpliada = new List<string>();
            coleccionAmpliada.Add("Cien años de soledad");
            coleccionAmpliada.Add("El Principito");
            coleccionAmpliada.Add("Don Quijote");
            coleccionAmpliada.Add("Harry Potter");

            Console.WriteLine("\n=== Colección Ampliada ===");
            foreach (string titulo in coleccionAmpliada)
            {
                Console.WriteLine($"- {titulo}");
            }
            Console.WriteLine($"Total: {coleccionAmpliada.Count}");

            Console.WriteLine("\n=== Resumen ===");
            Console.WriteLine("La primera colección mantiene una cantidad fija de títulos.");
            Console.WriteLine("La segunda colección permite agregar más títulos con facilidad.");
            Console.WriteLine("Ambas opciones sirven para organizar información del sistema.");
        }
    }
}
