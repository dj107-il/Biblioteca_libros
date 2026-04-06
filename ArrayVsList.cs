namespace Biblioteca_libros
{
    public class ArrayVsList
    {
        public static void Comparar()
        {
            // ── ARRAY ────────────────────────────────────────────
            // Tamaño fijo, debes saber cuántos elementos habrá
            string[] titulosArray = new string[3];
            titulosArray[0] = "Cien años de soledad";
            titulosArray[1] = "El Principito";
            titulosArray[2] = "Don Quijote";

            Console.WriteLine("=== Con Array ===");
            foreach (string titulo in titulosArray)
            {
                Console.WriteLine($"  - {titulo}");
            }
            Console.WriteLine($"Total: {titulosArray.Length}");

            // ── LIST ─────────────────────────────────────────────
            // Tamaño dinámico, crece según necesites
            List<string> titulosList = new List<string>();
            titulosList.Add("Cien años de soledad");
            titulosList.Add("El Principito");
            titulosList.Add("Don Quijote");
            titulosList.Add("Harry Potter"); // ← con array esto no era posible sin redimensionar

            Console.WriteLine("\n=== Con List ===");
            foreach (string titulo in titulosList)
            {
                Console.WriteLine($"  - {titulo}");
            }
            Console.WriteLine($"Total: {titulosList.Count}");

            // ── DIFERENCIAS ──────────────────────────────────────
            Console.WriteLine("\n=== Diferencias ===");
            Console.WriteLine("Array: tamaño fijo, no puede crecer.");
            Console.WriteLine("List:  tamaño dinámico, crece con Add().");
            Console.WriteLine("Array: usa .Length para contar.");
            Console.WriteLine("List:  usa .Count para contar.");
            Console.WriteLine("List:  tiene métodos como Add(), Remove(), Sort().");
        }
    }
}