namespace Biblioteca_libros;

class Program
{
    static void Main(string[] args)
    {
        MostrarBienvenida();
        MostrarMenuPrincipal();
    }

    static void MostrarBienvenida()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("        📚Bienvenido a SmartLibrary        ");
        Console.WriteLine("     Sistema de gestión de biblioteca.     ");
        Console.WriteLine("===========================================");
    }

    static void MostrarMenuPrincipal()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("    Menu Principal     ");
            Console.WriteLine("=======================");
            Console.WriteLine("1. Libros.");
            Console.WriteLine("2. Usuarios.");
            Console.WriteLine("3. Préstamos.");
            Console.WriteLine("4. Búsqueda y reportes.");
            Console.WriteLine("5. Guardar / Cargar datos.");
            Console.WriteLine("6. Salir.");
            Console.Write("Ingresa la opción a la que deseas ingresar: ");
            opcion = int.Parse(Console.ReadLine() ?? "0");

            switch(opcion)
            {
                case 1:
                    //proximamente la funcion con los menú de libros
                    break;

                case 2:
                    //Proximamente la función del menú de los usuarios.
                    break;

                case 3:
                    //Proximamente la función del menu de los prestamos.
                    break;

                case 4: 
                    //Proximamente la función del menu de busqueda y reportes.
                    break;

                case 5: 
                    //Proximamente la función del menu de Guardar / Cargar datos.
                    break;

                case 6: 
                    ConfirmarSalidaYGuardar();
                    break;
                
                default:
                    Console.WriteLine("Opcion incorrecta, intentalo nuevamente");
                    Console.WriteLine("Presiona Enter para continuar...");
                    Console.ReadLine(); // pausa para que el usuario lea el mensaje antes del Clear
                    MostrarMenuPrincipal();
                    break;

            }
        }while(opcion != 6);
    }

    static void ConfirmarSalidaYGuardar()
    {
        Console.WriteLine("Señor usuario quiere ¿Guardar los datos antes de salir? (S/N)");
        string respuesta = Console.ReadLine() ?? "";

        if(respuesta.ToUpper() == "S")
        {
            Console.WriteLine("Guardando datos...");
            Console.WriteLine("Los datos se han guardado exitosamente. ✅");
            Console.WriteLine("¡Hasta luego!");
        }
        else if(respuesta.ToUpper() == "N")
        {
            Console.WriteLine("Saliendo sin guardar...");
            Console.WriteLine("🔁🔁🔁");
            Console.WriteLine("Has salido sin guardar los datos exitosamente.✅");
            Console.WriteLine("¡Hasta luego!");
        }
        else
        {
            Console.WriteLine("respuesta invalida. Se canceló la salida...");
        }
    }
}
