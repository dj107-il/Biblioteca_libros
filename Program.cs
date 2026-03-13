using System.Collections;
using System.ComponentModel;

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
                    MostrarMenuLibros();
                    break;

                case 2:
                    //Proximamente la función del menú de los usuarios.
                    MostrarMenuUsuarios();
                    break;

                case 3:
                    //Proximamente la función del menu de los prestamos.
                    MostrarMenuPrestamos();
                    break;

                case 4: 
                    //Proximamente la función del menu de busqueda y reportes.
                    MostrarMenuBusquedaReportes();
                    break;

                case 5: 
                    //Proximamente la función del menu de Guardar / Cargar datos.
                    MostrarMenuGuardarCargarDatos();
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

    static void MostrarMenuLibros()
    {
        int menu_libros;
        do
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("   Menu de Libros   ");
            Console.WriteLine("====================");
            Console.WriteLine("1. Registrar libros.");
            Console.WriteLine("2. Listar libros.");
            Console.WriteLine("3. Ver detalles del libro(por ID/ISBN).");
            Console.WriteLine("4. Actualizar libro.");
            Console.WriteLine("5. Eliminar libro.");
            Console.WriteLine("6. Volver al menu principal.");
            Console.Write("Elija una de las opciones a la que desea ingresar: ");
            menu_libros = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_libros)
            {
                case 1:
                    //Funcion registrar usuario
                    RegistrarLibro();
                    break;

                case 2:
                    //Funcion para listar libros que va a ir otro menu
                    MenuListarLibros();
                    break;

                case 3:
                    //Funcion para ver los detalles del libro(por ID/ISBN)
                    MostrarDetallesLibro();
                    break;

                case 4:
                    //Funcion para ver otro menu que seria la seccion para actualizar un libro
                    MenuActualizarLibro();
                    break;

                case 5:
                    //Funcion para elminar un libro
                    EliminarLibro();
                    break;

                case 6:
                    Console.WriteLine("Volviendo al menú principal...");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;
                
                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    MostrarMenuLibros();
                    break;
            }
        } while (menu_libros != 6);
    }

    static void RegistrarLibro()
    {
        Console.Clear();
        Console.WriteLine("===  Registro de libro  ===");
        Console.Write("Señor usuario ingrese el ID/ISBN del libro: ");
        string id = Console.ReadLine() ?? ""; 

        Console.Write("Ingresa el titulo del libro: "); 
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Ingresa el autor del libro: ");
        string autor = Console.ReadLine() ?? "";

        Console.Write("Ingresa la categoria del libro: ");
        string categoria = Console.ReadLine() ?? "";

        Console.Write("Ingresa el año de publicación del libro: ");
        string año_publicacion = Console.ReadLine() ?? "";

        Console.WriteLine($"\n>> El libro {titulo} de {autor} se ha registrado exitosamente."); 
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MenuListarLibros()
    {
        int menu_listar_libros;
        do
        {
            Console.Clear();
            Console.WriteLine("=====================");
            Console.WriteLine("   Listar libros     ");
            Console.WriteLine("=====================");
            Console.WriteLine("1. Listar todos los libros ");
            Console.WriteLine("2. Listar todos los libros disponibles");
            Console.WriteLine("3. Listar todos los libros prestados");
            Console.WriteLine("4. Volver al menú de los libros");

            Console.Write("¿Qué opción desea ingresar? ");
            menu_listar_libros = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_listar_libros)
            {
                case 1:
                    //Funcion para listar todos los libros
                    ListarTodosLibros();
                    break;
                case 2:
                    //funcion para listar todos los libros disponibles
                    ListarLibrosDisponibles();
                    break;
                case 3: 
                    //Función para listar todos los libros prestados
                    ListarLibrosPrestados();
                    break;
                case 4:
                    //Volver al menu de libros
                    Console.WriteLine("Regresando al menu de libros...");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;

                default: 
                    Console.WriteLine("Opcion invalida, intetalo nuevamente.");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }while(menu_listar_libros != 4);
    }

    static void ListarTodosLibros()
    {
        Console.Clear();
        Console.WriteLine("\n==============================  Listar todos los libros  =====================================");
        Console.WriteLine("  ID               Título                   Autor             Categoría      Año    Disponible");
        Console.WriteLine("978-3-16      Cien años de soledad       Gabriel García        Novela        1967      si     ");
        Console.WriteLine("978-1-23      El Principito              Saint-Exupéry         Infantil      1943      no     ");
        Console.WriteLine("978-4-56      Don Quijote                Miguel de Cervantes   Clásico       1605      si     ");
        Console.WriteLine("\n>>> Se listarían todos los libros registrados en el sistema.");
        Console.WriteLine("\n==============================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ListarLibrosDisponibles()
    {  
        Console.Clear();
        Console.WriteLine("\n====================== Listar libros disponibles ================================");
        Console.WriteLine("  ID               Título                 Autor              Categoría       Año ");
        Console.WriteLine("978-3-16      Cien años de soledad    Gabriel García           Novela        1967");
        Console.WriteLine("978-4-56      Don Quijote            Miguel de Cervantes       Clásico       1605");
        Console.WriteLine("\n>>> Se listarían solo los libros disponibles para préstamo.");
        Console.WriteLine("\n=================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ListarLibrosPrestados()
    {
        Console.Clear();
        Console.WriteLine("\n=======================  Listar libros prestados  ==============================");
        Console.WriteLine("ID            Título                    Autor                Categoría       Año");
        Console.WriteLine("978-1-23    El Principito            Saint-Exupéry           Infantil       1943");
        Console.WriteLine("\n>>> Se listarían solo los libros que actualmente están prestados.");
        Console.WriteLine("\n================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarDetallesLibro()
    {
        Console.Clear();
        Console.WriteLine("==== Ver detalles del libro (por id/ISBN) ===");
        Console.Write("Señor usuario ingrese el id o ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine($"⏸  Mostrando los detalles del libro           ⏸");
        Console.WriteLine($"⏸  ID/ISBN: {id_isbn.PadRight(35)}⏸");
        Console.WriteLine("⏸  Titulo: Los cien años de maravilla         ⏸");
        Console.WriteLine("⏸  Autor: Luis Fernando Sanchez               ⏸");
        Console.WriteLine("⏸  Categoria: Nostalgia, romance.             ⏸");
        Console.WriteLine("⏸  Año de publicación: 2021                   ⏸");
        Console.WriteLine("⏸  Disponible: Si                             ⏸");
        Console.WriteLine("================================================");
        Console.Write("\nPresiona Enter para continuar...           ");
        Console.ReadLine();
    }

    static void MenuActualizarLibro()
    {
        int opcion_actualizar_libro;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("    Menu de Actualizar libro     ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Editar título.");
            Console.WriteLine("2. Editar autor.");
            Console.WriteLine("3. Editar año/categoría.");
            Console.WriteLine("4. Volver al menu de los libros.");
            Console.Write("Ingresa la opción que deseas ingresar: ");
            opcion_actualizar_libro = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion_actualizar_libro)
            {
                case 1: 
                    //Función para editar titulo de un libro
                    EditarTituloLibro();
                    break;

                case 2:
                    //Función para editar el autor de un libro
                    EditarAutorLibro();
                    break;

                case 3:
                    //Función para editar el año/categoria de un libro
                    EditarAñoCategoriaLibro();
                    break;

                case 4:
                    //Volver al menu de libros
                    Console.WriteLine("Regresando al menu de libros...");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción invalida. Intentalo nevamente.");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }   
        }while(opcion_actualizar_libro != 4);
    }

    static void EditarTituloLibro()
    {
        Console.Clear();
        Console.WriteLine("=== Editar titulo del libro ===");
        Console.Write("Señor usuario ingrese el ID o ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Console.WriteLine($"El id/ISBN: {id_isbn}  de este libro tiene como titulo: las cien maravillas.");
        Console.Write("Señor usuario ingrese el nuevo titulo del libro: ");
        string nuevo_titulo = Console.ReadLine() ?? "";
        Console.WriteLine("Editando el titulo del libro... ");
        Console.WriteLine("El titulo del libro se ha cambiado completamente exitosamente. ✅");
        Console.WriteLine("\n===============================");
        Console.WriteLine("  Mostrando los cambios          ");
        Console.WriteLine($"  ID/ISBN del libro: {id_isbn}   ");
        Console.WriteLine($"  Titulo: {nuevo_titulo}        ");
        Console.WriteLine("===============================");
        Console.Write("\nPresiona Enter para continuar....");
        Console.ReadLine();
    }

    static void EditarAutorLibro()
    {
        Console.Clear();
        Console.WriteLine("==== Editar autor del libro ====");
        Console.Write("Señor usuario ingrese el ID o ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Console.WriteLine($"El ID/ISBN: {id_isbn} del libro tiene como autor: Luis sancocho");
        Console.Write("Señor usuario ingrese el nuevo autor del libro: ");
        string nuevo_autor = Console.ReadLine() ?? "";
        Console.WriteLine("Editando el autor del libro... ");
        Console.WriteLine($"El autor del libro con ID/ISBN: {id_isbn} se ha cambiado completamente exitosamente.✅");
        Console.WriteLine("\n===============================");
        Console.WriteLine("  Mostrando los cambios          ");
        Console.WriteLine($"  ID/ISBN del libro: {id_isbn}   ");
        Console.WriteLine($"  Autor: {nuevo_autor}          ");
        Console.WriteLine("===============================");
        Console.Write("\nPresiona Enter para continuar....");
        Console.ReadLine();
    }

    static void EditarAñoCategoriaLibro()
    {
        string respuesta;
        do
        {
        Console.Clear();
        Console.WriteLine("===  Editar año/categoria del libro  ===");
        Console.Write("Señor usuario ingrese el ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Console.WriteLine($"El ID/ISBN: {id_isbn} del libro tiene como año de publicación: 2013 y su categoria es: suspenso,drama.");
        Console.WriteLine("¿Qué es lo que quieres editar el año o la categoria?(año/categoria)");
        respuesta = Console.ReadLine() ?? "";

        if (respuesta.ToLower() == "año")
        {
            Console.Clear();
            Console.WriteLine("=== Editando el año de la publicación del libro. ===");
            string nuevo_año_publicacion;

            do{
                Console.Write("Señor usuario ingrese el nuevo año de la publicación del libro:");
                nuevo_año_publicacion = Console.ReadLine() ?? "";
                if(!int.TryParse(nuevo_año_publicacion, out _) || nuevo_año_publicacion.Length != 4)
                {
                    Console.WriteLine("El año no es valido, debe ser un numero de 4 digitos.");
                }
            } while(!int.TryParse(nuevo_año_publicacion, out _) || nuevo_año_publicacion.Length != 4);

            Console.WriteLine("Editando el año de la publicación del libro... ");
            Console.WriteLine($"Se ha modificado con exito el año de la publicaión del libro {id_isbn}.✅");
            Console.WriteLine("\n===============================");
            Console.WriteLine("  Mostrando los cambios           ");
            Console.WriteLine($"  ID/ISBN del libro: {id_isbn}   ");
            Console.WriteLine($"  Año de publicacion: {nuevo_año_publicacion} ");
            Console.WriteLine("===============================");
            Console.Write("\nPresiona Enter para continuar....");
            Console.ReadLine(); 
        }
        else if(respuesta.ToLower() == "categoria")
        {
            Console.Clear();
            Console.WriteLine("=== Editando la categoria del libro. ==="); 
            Console.Write("Señor usuario ingrese la nueva categoria del libro: ");
            string nueva_categoria = Console.ReadLine() ?? "";
            Console.WriteLine("Se esta editando la categoria del libro... ");
            Console.WriteLine("Se ha modificado con exito la categoria del libro.✅");
            Console.WriteLine("\n===============================");
            Console.WriteLine("  Mostrando los cambios           ");
            Console.WriteLine($"  ID/ISBN del libro: {id_isbn}   ");
            Console.WriteLine($"  Categoria: {nueva_categoria} ");
            Console.WriteLine("===============================");
            Console.Write("\nPresiona Enter para continuar....");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Se ingreso una respuesta invalida, por favor intentalo nuevamente.");
            Console.WriteLine("Recuerda tienes que responder: año o categoria, gracias."); 
            Console.Write("Presiona Enter para continuar... ");
            Console.ReadLine();
        }
        } while (respuesta.ToLower() != "año" && respuesta.ToLower() != "categoria");
    }

    static void EliminarLibro()
    {
        Console.Clear();
        Console.WriteLine("===  Eliminar un libro  ===");
        Console.Write("Señor usuario ingrese el ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Console.Write($"¿El libro {id_isbn} esta en prestamo actualmente?(S/N)");
        string prestado = Console.ReadLine() ?? "";

        if(prestado.ToUpper() == "S")
        {
            Console.WriteLine("No se puede eliminar: el libro está prestado actualmente.");
        }
        else if(prestado.ToUpper() == "N")
        {
            Console.Write($"¿Confirmas eliminar el libro con ID/ISBN {id_isbn}? (S/N): ");
            string confirmar = Console.ReadLine() ?? "";

            if (confirmar.ToUpper() == "S")
            {   
                Console.WriteLine(" El libro ha sido eliminado correctamente. ✅");
            }
            else
            {   
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Opción invalida. Cancelando la operación...");
        }
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarMenuUsuarios(){}
    static void MostrarMenuPrestamos(){}
    static void MostrarMenuBusquedaReportes(){}
    static void MostrarMenuGuardarCargarDatos(){}
}
