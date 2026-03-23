using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

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
        Console.Clear();
        Console.WriteLine("Señor usuario quiere ¿Guardar los datos antes de salir del sistema? (S/N)");
        string confirmacion_salir = Console.ReadLine() ?? "";

        if(confirmacion_salir.ToUpper() == "S")
        {
            Console.WriteLine("Guardando los datos...");
            Console.WriteLine("Los datos se guardaron exitosamente. ✅");
            Console.WriteLine("Gracias por usar nuestro sistema. ¡Hasta luego!");
        }
        else if(confirmacion_salir.ToUpper() == "N")
        {
            Console.WriteLine("Saliendo sin guardar los datos...");
            Console.WriteLine("Cerrando el sistema...");
            Console.WriteLine("Has salido exitosamente sin guardar los datos.✅");
            Console.WriteLine("Gracias por usar nuestro sistema. ¡Hasta luego!");
        }
        else
        {
            Console.WriteLine("Señor usuario la respuesta que ingresastes es invalida.");
            Console.WriteLine("Por lo tanto se canceló la operación de guardar los datos para salir.");       
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
                    //Funcion registrar libro
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
        } while (menu_listar_libros != 4);
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

        // Objetos de prueba 
        Libro libro1 = new Libro(
            "Cien años de soledad", 
            "García Márquez", 
            "978-3-16", 
            "Novela", 
            1967, 
            true);

        Libro libro2 = new Libro(
            "Las cien maravillas",
            "Fernando Marquez",
            "978-2-13",
            "Drama,comedia",
            1977,
            true
        );

        Console.Clear();
        Console.WriteLine("=== Libro 1 ===");
        libro1.ResumenCorto();
        libro1.DetalleCompleto(); // <-- Aunque ya tiene validacion adentro de la clase
        Console.WriteLine($"Disponible: {(libro1.Disponible ? "Sí" : "No")}");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();

        Console.WriteLine("\n=== Libro 2 ===");
        libro2.ResumenCorto();
        libro2.DetalleCompleto(); // <-- Aunque ya tiene validacion adentro de la clase
        Console.WriteLine($"Disponible: {(libro2.Disponible ? "Sí" : "No")}");
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
        } while (opcion_actualizar_libro != 4);
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

                do
                {
                    Console.Write("Señor usuario ingrese el nuevo año de la publicación del libro:");
                    nuevo_año_publicacion = Console.ReadLine() ?? "";
                    if (!int.TryParse(nuevo_año_publicacion, out _) || nuevo_año_publicacion.Length != 4)
                    {
                        Console.WriteLine("El año no es valido, debe ser un numero de 4 digitos.");
                    }
                } while (!int.TryParse(nuevo_año_publicacion, out _) || nuevo_año_publicacion.Length != 4);

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
            else if (respuesta.ToLower() == "categoria")
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

        if (prestado.ToUpper() == "S")
        {
            Console.WriteLine("No se puede eliminar: el libro está prestado actualmente.");
        }
        else if (prestado.ToUpper() == "N")
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

    static void MostrarMenuUsuarios()
    {
        
        int menu_usuarios;
        do
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("   Menu de Usuarios   ");
            Console.WriteLine("======================");
            Console.WriteLine("1. Registrar usuario.");
            Console.WriteLine("2. Listar usuarios.");
            Console.WriteLine("3. Ver detalles del usuario(por ID/Documento).");
            Console.WriteLine("4. Actualizar usuario.");
            Console.WriteLine("5. Eliminar usuario.");
            Console.WriteLine("6. Volver al menu principal.");
            Console.Write("Elija una de las opciones a la que desea ingresar: ");
            menu_usuarios = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_usuarios)
            {
                case 1:
                    //Funcion registrar usuario
                    RegistrarUsuario();
                    break;

                case 2:
                    //Funcion para listar usuarios
                    ListarUsuarios();
                    break;

                case 3:
                    //Funcion para ver los detalles del usuario(por ID/Documento)
                    MostrarDetallesUsuario();
                    break;

                case 4:
                    //Funcion para ver otro menu que seria la seccion para actualizar un usuario
                    MenuActualizarUsuario();
                    break;

                case 5:
                    //Funcion para eliminar un usuario
                    EliminarUsuario();
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
                    break;
                    
            } 
        } while (menu_usuarios != 6);
    }

    static void RegistrarUsuario()
    {
        Console.Clear();
        Console.WriteLine("===  Registro de Usuario  ===");
        Console.Write("Señor usuario ingrese el ID/Documento: ");
        string id_documento = Console.ReadLine() ?? "";

        Console.Write("Ingresa el nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Ingresa el apellido: ");
        string apellido = Console.ReadLine() ?? "";

        Console.Write("Ingresa el telefono de contacto: ");
        string telefono = Console.ReadLine() ?? "";

        Console.Write("Ingresa el correo electrónico: ");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine($"\n>> El usuario {nombre} {apellido} ha sido registrado exitosamente con el {id_documento}. ✅");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ListarUsuarios()
    {
        Console.Clear();
        Console.WriteLine("\n==============================  Listar todos los usuarios  =======================================");
        Console.WriteLine("ID/Documento      nombre           Apellido        Telefono       Correo Electrónico     Estado     ");
        Console.WriteLine(" 978-3-16         David             García         3013191210     DavidG@gmail.com       Activo       ");
        Console.WriteLine(" 978-1-23         Juan              Eureka         3213211311     JEureka@hotmail.com    Activo       ");
        Console.WriteLine(" 978-4-56        Camilo            Cervantes       3014192310      CamiloC@gmail.com   Desactivado  ");
        Console.WriteLine("\n>>> Se listarían todos los usuarios registrados en el sistema.");
        Console.WriteLine("\n==================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarDetallesUsuario()
    {
        Console.Clear();
        Console.WriteLine("==== Ver detalles del usuario (por id/Documento) ===");
        Console.Write("Señor usuario ingrese el id o documento del usuario registrado: ");
        string id_documento = Console.ReadLine() ?? "";

        // Objetos de prueba 
            Usuario usuario1 = new Usuario(
            "Luis",
            "Sanchez",
            "1012312122",
            "Dc@gmail.com",
            "3013212422",
            false
        );

        Usuario usuario2 = new Usuario(
            "Fernando",
            "Palomo",
            "13412-12-1",
            "fernandoP@hotmail.com",
            "3013212132",
            true
        );

        Console.Clear();
        Console.WriteLine("=== Usuario 1 ===");
        usuario1.ResumenCorto();
        usuario1.DetalleCompleto(); // <-- Aunque ya tiene validacion adentro de la clase
        Console.WriteLine($"Activo: {(usuario1.Activo ? "Sí" : "No")}");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("=== Usuario 2 ===");
        usuario2.ResumenCorto();
        usuario2.DetalleCompleto(); // <-- Aunque ya tiene validacion adentro de la clase
        Console.WriteLine($"Activo: {(usuario2.Activo ? "Sí" : "No")}");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MenuActualizarUsuario()
    {
        int opcion_actualizar_usuario;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("    Menú de Actualizar Usuario    ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Editar nombre.");
            Console.WriteLine("2. Editar contacto de telefono.");
            Console.WriteLine("3. Activar/desactivar usuario.");
            Console.WriteLine("4. Volver al menu de los usuario.");
            Console.Write("Ingresa la opción que deseas ingresar: ");
            opcion_actualizar_usuario = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion_actualizar_usuario)
            {
                case 1:
                    //Función para editar el nombre de un usuario
                    EditarNombreUsuario();
                    break;

                case 2:
                    //Función para editar el contacto telefonico de un usuario
                    EditarContactoUsuario();
                    break;

                case 3:
                    //Función para Activar/Desactivar el usuario
                    ActivarDesactivarUsuario();
                    break;

                case 4:
                    //Volver al menu de libros
                    Console.WriteLine("Regresando al menú de usuario...");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente.");
                    Console.Write("Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (opcion_actualizar_usuario != 4);
        
    }

    static void EditarNombreUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== Editar nombre del usuario ===");
        Console.Write("Señor usuario ingrese el ID o Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";

        Console.WriteLine($"El id/Documento: {id_documento}  de este usuario tiene como nombre: Luis Fernando.");
        Console.Write("Señor usuario ingrese el nuevo nombre del usuario: ");
        string nuevo_nombre = Console.ReadLine() ?? "";

        Console.WriteLine("Editando el nombre del usuario... ");
        Console.WriteLine("El nombre del usuario se ha cambiado exitosamente. ✅");
        Console.WriteLine("\n===================================");
        Console.WriteLine("  Mostrando los cambios del usuario          ");
        Console.WriteLine($"  ID/Documento del usuario: {id_documento}  ");
        Console.WriteLine($"  Nombre: {nuevo_nombre}        ");
        Console.WriteLine("===================================");
        Console.Write("\nPresiona Enter para continuar....");
        Console.ReadLine();   
    }

    static void EditarContactoUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== Editar Contacto telefónico del usuario ===");
        Console.Write("Señor usuario ingrese el ID o Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";

        Console.WriteLine($"El ID/Documento: {id_documento} de este usuario tiene como contacto telefónico: 3124356787");
        Console.Write("Señor usuario ingrese el nuevo contacto telefónico: ");
        string nuevo_contacto = Console.ReadLine() ?? "";

        Console.WriteLine("Editando el contacto del usuario... ");
        Console.WriteLine("El contacto telefónico del usuario se ha cambiado exitosamente. ✅");
        Console.WriteLine("\n=======================================");
        Console.WriteLine("  Mostrando los cambios del usuario    ");
        Console.WriteLine($"  ID/Documento del usuario: {id_documento}   ");
        Console.WriteLine($"  Contacto: {nuevo_contacto}        ");
        Console.WriteLine("=======================================");
        Console.Write("\nPresiona Enter para continuar....");
        Console.ReadLine();
    }

    static void ActivarDesactivarUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== Activar/Desactivar del Usuario ===");
        Console.Write("Señor usuario ingrese el ID o Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";

        Random aleatorio = new Random();
        int estadoRandom = aleatorio.Next(0, 2); // genera 0 o 1
        string estado = estadoRandom == 1 ? "Activo" : "Desactivado";

        Console.WriteLine($"El id/Documento: {id_documento} del iusuario esta {estado}");
        Console.WriteLine("¿Señor usuario quieres activar o desactivar el usuario?");
        string activar_desactivar = Console.ReadLine() ?? "";

        if (activar_desactivar.ToLower() == "activar")
        {
            Console.WriteLine("Activando el estado del usuario... ");
            Console.WriteLine("El estado del usuario se ha activado exitosamente. ✅");
            Console.WriteLine($"\n  ID/Documento: {id_documento}");
            Console.WriteLine("  Estado: Activo");
        }
        else if(activar_desactivar.ToLower() == "desactivar")
        {
            Console.WriteLine("Desactivando el estado del usuario... ");
            Console.WriteLine("El estado del usuario se ha desactivado exitosamente. ✅");
            Console.WriteLine($"\n  ID/Documento: {id_documento}");
            Console.WriteLine("  Estado: Desactivado");
        }
        else
        {
            Console.WriteLine("Opción no válida, se canceló la operación.");
        }
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();

    }
    static void EliminarUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== Eliminar Usuario ===");
        Console.Write("Señor usuario ingrese el ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        Console.Write($"Señor usuario ¿Tienes prestamos activos?(S/N)");
        string activo_prestamo = Console.ReadLine() ?? "";

        if (activo_prestamo.ToUpper() == "S")
        {
            Console.WriteLine("No se puede eliminar el usuario, porqué tienes prestamos activos.");
        }
        else if (activo_prestamo.ToUpper() == "N")
        {
            Console.Write($"¿Confirmas eliminar el usuario con ID/Documento {id_documento}? (S/N): ");
            string confirmar = Console.ReadLine() ?? "";

            if (confirmar.ToUpper() == "S")
            {
                Console.WriteLine("El usuario ha sido eliminado correctamente. ✅");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Opción invalida. Cancelando la operación de eliminar el usuario...");
        }
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarMenuPrestamos()
    {
        int menu_prestamos;
        do
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("   Menu de Préstamos   ");
            Console.WriteLine("======================");
            Console.WriteLine("1. Crear préstamos.");
            Console.WriteLine("2. Listar préstamos.");
            Console.WriteLine("3. Ver detalles de préstamo(por ID).");
            Console.WriteLine("4. Registrar devolución.");
            Console.WriteLine("5. Eliminar préstamo.");
            Console.WriteLine("6. Volver al menu principal.");
            Console.Write("Elija una de las opciones a la que desea ingresar: ");
            menu_prestamos = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_prestamos)
            {
                case 1:
                    //Funcion que crea un prestamo(con validaciones)
                    CrearPrestamo();
                    break;

                case 2:
                    //Funcion para ver un submenu de listar los prestamos
                    MenuListarPrestamos();
                    break;

                case 3:
                    //Funcion para ver los detalles del prestamo(por ID)
                    MostrarDetallesPrestamo();
                    break;

                case 4:
                    //Funcion para ver otro menu que seria la sección de registrar devolución
                    RegistrarDevolucion();
                    break;

                case 5:
                    //Funcion para eliminar un préstamo
                    EliminarPrestamo();
                    break;

                case 6:
                    Console.WriteLine("Volviendo al menú principal...");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente");
                    Console.Write("\nPresiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (menu_prestamos != 6);
    }

    static void CrearPrestamo()
    {
        Console.Clear();
        Console.WriteLine("=== Crear préstamo ===");
        Console.Write("Ingrese el ID/Documento del usuario: ");
        string id_usuario = Console.ReadLine() ?? "";
        Console.Write("Ingrese el ID/ISBN del libro: ");
        string id_libro = Console.ReadLine() ?? "";

        Console.WriteLine("\nValidaciones que se aplicarían:");
        Console.WriteLine("  --> Verificar que el usuario existe y está activo.");
        Console.WriteLine("  --> Verificar que el libro existe y está disponible.");
        Console.WriteLine("  --> Verificar que el usuario no supera el límite de préstamos activos.");
        Console.WriteLine($"\nPréstamo del libro {id_libro} al usuario {id_usuario} creado exitosamente. ✅");

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MenuListarPrestamos()
    {
        int opcion_prestamo;
        do
        {        
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("  Listar Préstamos  ");
            Console.WriteLine("====================");
            Console.WriteLine("1. Listar todos los préstamos. ");
            Console.WriteLine("2. Listar los préstamos activos.");
            Console.WriteLine("3. Listar los préstamos cerrados(devueltos)");
            Console.WriteLine("4. Volver al menú principal. ");
            Console.WriteLine("¿Que opción desea ingresa?");
            opcion_prestamo = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion_prestamo)
            {
                case 1:
                    //Función para listar todos los préstamos
                    ListarTodosPrestamos();
                    break;
                
                case 2: 
                    //función para listar los préstamos activos que hay
                    ListarPrestamosActivos();
                    break;

                case 3:
                    //Función para listar los préstamos cerrados(devueltos) que hay
                    ListarPrestamosCerrados();
                    break;

                case 4:
                    Console.WriteLine("Volviendo al menú principal... ");
                    Console.Write("\nPresiona Enter para continuar... ");
                    Console.ReadLine();
                    break;

                default: 
                    Console.WriteLine("La opción que ingresastes es invalida. Intentalo nuevamente... ");
                    Console.WriteLine("\nPresiona Enter para continuar... ");
                    Console.ReadLine();
                    break;
            }
        }while(opcion_prestamo != 4);
    }

    static void ListarTodosPrestamos()
    {
        Console.Clear();
        Console.WriteLine("\n==============================  Listar todos los préstamos  =========================================");
        Console.WriteLine("ID Préstamo   ID Usuario   ID/ISBN Libro   Fecha Préstamo   Fecha Límite  Fecha Devolución   Estado   ");
        Console.WriteLine("  P-001         978-3-16      978-1-23        2024-01-10      2024-06-24        null         Activo   ");
        Console.WriteLine("  P-002         978-4-56      978-3-16        2024-02-05      2024-08-19        null         Cerrado  ");
        Console.WriteLine("  P-003         978-1-23      978-4-56        2024-03-01      2024-11-15        null         Activo   ");
        Console.WriteLine("\n>>> Se listarían todos los préstamos registrados en el sistema.");
        Console.WriteLine("=====================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ListarPrestamosActivos()
    {
        Console.Clear();
        Console.WriteLine("\n============================== Listar todos los préstamos activos =====================================");
        Console.WriteLine("ID Préstamo   ID Usuario   ID/ISBN Libro   Fecha Préstamo   Fecha Límite   fecha devolución      Estado  ");
        Console.WriteLine("  P-010         988-8-19      978-5-25        2024-06-11      2025-01-01        null             Activo  ");
        Console.WriteLine("  P-020         900-5-59      978-8-18        2024-03-09      2024-09-27        null             Activo  ");
        Console.WriteLine("  P-070         995-6-29      978-9-57        2024-04-10      2024-10-30        null             Activo  ");
        Console.WriteLine("\n>>> Se listarían todos los préstamos activados registrados en el sistema.");
        Console.WriteLine("=======================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ListarPrestamosCerrados()
    {
        Console.Clear();
        Console.WriteLine("\n==============================  Listar todos los préstamos cerrados(devueltos)  =========================");
        Console.WriteLine("ID Préstamo   ID Usuario   ID/ISBN Libro   Fecha Préstamo   Fecha Límite   fecha devolución    Estado   ");
        Console.WriteLine("  P-105         978-9-21      908-6-99        2024-06-09      2025-01-01     2024-12-10        Cerrado   ");
        Console.WriteLine("  P-096         916-5-61      938-1-20        2024-01-31      2024-08-24     2024-05-30        Cerrado  ");
        Console.WriteLine("  P-099         935-8-91      918-9-60        2024-08-28      2024-05-30     2024-05-28        Cerrado  ");
        Console.WriteLine("\n>>> Se listarían todos los préstamos cerrados(devueltos) registrados en el sistema.");
        Console.WriteLine("\n=========================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarDetallesPrestamo()
    {
        Console.Clear();
        Console.Write("Señor usuario ingrese el id del préstamo registrado: ");
        string id_prestamo = Console.ReadLine() ?? "";

        // Objetos de prueba
        Prestamo prestamo1 = new Prestamo(
            "P001",
            "1012312122",                        
            "978-3-16",   
            new DateTime(2024, 1, 11),
            new DateTime(2024, 6, 25),
            null,
            EstadoPrestamo.Activo
        );

        Console.Clear();
        Console.WriteLine("=== Préstamo 1 ===");
        prestamo1.ResumenCorto();
        prestamo1.DetalleCompleto(); // <-- Aunque ya tiene validacion adentro de la clase
        Console.WriteLine($"Estado: {prestamo1.Estado}");
        Console.WriteLine($"Esta vencido: {(prestamo1.EstaVencido() ? "Sí" : "No")}");
        Console.WriteLine($"Días transcurridos: {prestamo1.DiasTranscurridos()}");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void RegistrarDevolucion()
    {
        Console.Clear();
        Console.WriteLine("=== Registrar devolución ===");
        Console.Write("Señor usuario ingrese el ID del prestamo: ");
        string id_prestamo = Console.ReadLine() ?? "";

        Console.WriteLine($"\nProcesando devolución del préstamo {id_prestamo}...");
        Console.WriteLine("El préstamo ha sido marcado como Cerrado. ✅");
        Console.WriteLine("El libro ha sido marcado como Disponible. ✅");
        Console.WriteLine("Fecha de devolución registrada: 2024-10-27");

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void EliminarPrestamo()
    {
        Console.Clear();
        Console.WriteLine("===  Eliminar Préstamo  ===");
        Console.Write("Señor usuario ingrese el ID del prestamo: ");
        string id_prestamo = Console.ReadLine() ?? "";

        Console.Write($"¿El préstamo {id_prestamo} está cerrado(devuelto)? (S/N): ");
        string cerrado = Console.ReadLine() ?? "";

        if (cerrado.ToUpper() == "S")
        {
            Console.Write($"¿Confirmas eliminar el préstamo {id_prestamo}? (S/N): ");
            string confirmar = Console.ReadLine() ?? "";

            if (confirmar.ToUpper() == "S")
                Console.WriteLine("El préstamo del libro ha sido eliminado exitosamente. ✅");
            else
                Console.WriteLine("La eliminación del préstamo ha sido cancelado.❌");
        }
        else if (cerrado.ToUpper() == "N")
        {
            Console.Write("¿El préstamo fue creado por error? (S/N): ");
            string error = Console.ReadLine() ?? "";

            if (error.ToUpper() == "S")
            {
                Console.WriteLine("Eliminando préstamo creado por error...");
                Console.WriteLine("El libro ha sido marcado como Disponible nuevamente. ✅");
                Console.WriteLine("El préstamo del libro ha sido eliminado exitosamente. ✅");
            }
            else
            {
                Console.WriteLine("El préstamo no se puede eliminar porque está activo.");
                Console.WriteLine("Debe registrar la devolución del libro primero, gracias.");
            }
        }
        else
        {
            Console.WriteLine(">> Opción inválida. Cancelando la operación de eliminación del préstamo...");
        }
        

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }
    
    static void MostrarMenuBusquedaReportes()
    {
        int menu_busqueda_reportes;
        do
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("  Menú de búsqueda y reportes ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Buscar libro.");
            Console.WriteLine("2. Buscar usuario.");
            Console.WriteLine("3. Reportes.");
            Console.WriteLine("4. Volver al menú principal.");
            Console.Write("Elija una de las opciones a la que desea ingresar: ");
            menu_busqueda_reportes = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_busqueda_reportes)
            {
                case 1:
                    //Funcion para buscar un libro
                    BuscarLibro();
                    break;

                case 2:
                    //Funcion para buscar un usuario
                    BuscarUsuario();
                    break;

                case 3:
                    //Funcion para hacer reportes sobre préstamos
                    MenuReportes();
                    break;

                case 4:
                    Console.WriteLine("Volviendo al menú principal...");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente");
                    Console.Write("\nPresiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (menu_busqueda_reportes != 4);   
    }

    static void BuscarLibro()
    {
        Console.Clear();
        Console.WriteLine("Señor usuario por donde desea buscar el libro");
        Console.WriteLine("¿por título o autor o ID/ISBN o por categoría?");
        string respuesta_busqueda = Console.ReadLine() ?? "";

        if(respuesta_busqueda.ToLower() == "titulo")
        {
            Console.Clear();
            Console.WriteLine("¿Como se llama el libro?");
            string titulo_libro = Console.ReadLine() ?? "";

            Console.Clear();
            Console.WriteLine($"Buscando libro por el título: {titulo_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            Console.WriteLine("=======================================");                
            Console.WriteLine("           ID/ISBN: 978-3-16           ");
            Console.WriteLine($"        Título: {titulo_libro}        ");
            Console.WriteLine("          Autor: Gabriel García        ");
            Console.WriteLine("            Categoría: Novela          ");
            Console.WriteLine("                Año: 2000              ");
            Console.WriteLine("              Disponible: Si           ");
            Console.WriteLine("=======================================");
        }
        else if(respuesta_busqueda.ToLower() == "autor")
        {
            Console.Clear();
            Console.WriteLine("¿Como se llama el autor del libro?");
            string autor_libro = Console.ReadLine() ?? "*";

            Console.Clear();
            Console.WriteLine($"Buscando libro por el autor: {autor_libro}");
            Console.WriteLine("Los libros fueron encontrados exitosamente. ✅");
            Console.WriteLine("\n==================================================================================================");
            Console.WriteLine("  ID               Título              Autor     Categoría          Año   Disponible ");
            Console.WriteLine($"977-2-12       Las maravillas          {autor_libro}     Fantasia           1988     si     ");
            Console.WriteLine($"998-8-21       Los tolerantes          {autor_libro}     Suspenso           1975     no     ");
            Console.WriteLine($"912-7-98     Wilson y sus cagadas      {autor_libro}     Drama, Comedia     1990     si     ");
            Console.WriteLine($"\nSe listaron todos los libro populares que ha tenido el autor {autor_libro}.");
            Console.WriteLine("==================================================================================================");
        }
        else if(respuesta_busqueda.ToLower() == "id/isbn" || respuesta_busqueda.ToLower() == "id")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el ID/ISBN del libro?");
            string id_libro = Console.ReadLine() ?? "0";

            Console.Clear();
            Console.WriteLine($"Buscando libro por el ID/ISBN: {id_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            Console.WriteLine("=======================================");                
            Console.WriteLine($"              ID/ISBN: {id_libro}     ");
            Console.WriteLine("            Título: Los sureños        ");
            Console.WriteLine("           Autor: Esneider García      ");
            Console.WriteLine("            Categoría: Historia        ");
            Console.WriteLine("                Año: 2002              ");
            Console.WriteLine("              Disponible: Si           ");
            Console.WriteLine("=======================================");
        }
        else if(respuesta_busqueda.ToLower() == "categoria")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es la categoría del libro?");
            string categoria_libro = Console.ReadLine() ?? "";
            Console.Clear();
            Console.WriteLine($"Buscando libro por la categoría: {categoria_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            Console.WriteLine("=========================================");                
            Console.WriteLine("           ID/ISBN: 978-3-16           ");
            Console.WriteLine("       Título: El cerebro de wilson    ");
            Console.WriteLine("          Autor: Miguel Angel G        ");
            Console.WriteLine($"           Categoría: {categoria_libro}");
            Console.WriteLine("               Año: 2024               ");
            Console.WriteLine("             Disponible: Si            ");
            Console.WriteLine("=========================================");
        }
        else
        {
            Console.WriteLine("Has ingresado una respuesta invalida. Intentalo nuevamente.");
        }

        Console.Write("presiona Enter para continuar... ");
        Console.ReadLine();
    }

    static void BuscarUsuario()

    {
        Console.Clear();
        Console.WriteLine("Señor usuario por donde desea buscar el usuario");
        Console.WriteLine("¿por nombre o id/documento?");
        string respuesta_busqueda = Console.ReadLine() ?? "";

        if(respuesta_busqueda.ToLower() == "nombre")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el nombre del usuario que estas buscando?");
            string nombre_usuario = Console.ReadLine() ?? "Vacio";

            Console.Clear();
            Console.WriteLine($"Buscando al usuario por el nombre: {nombre_usuario}... ");
            Console.WriteLine("El usuario ha sido encontrado exitosamente. ✅");
            Console.WriteLine("========================================");
            Console.WriteLine("        ID/Documento: 1013245235        ");
            Console.WriteLine($"             Nombre: {nombre_usuario}      ");
            Console.WriteLine("          Apellido: Restrepo            ");
            Console.WriteLine("          Telefono: 3012414626          ");
            Console.WriteLine($"    Correo electrónico:{nombre_usuario[0]}R10@gmail.com");
            Console.WriteLine("           Estado: Activo");
            Console.WriteLine("========================================");
        }
        else if(respuesta_busqueda.ToLower() == "id/documento" || respuesta_busqueda.ToLower() == "id")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el ID/ISBN del usuario que estas buscando?");
            string id_usuario = Console.ReadLine() ?? "0";

            Console.Clear();
            Console.WriteLine($"Buscando al usuario por el id/documento: {id_usuario}... ");
            Console.WriteLine("El usuario ha sido encontrado exitosamente. ✅");
            Console.WriteLine("===============================================");
            Console.WriteLine($"            ID/Documento: {id_usuario}           ");
            Console.WriteLine("                Nombre: David                 ");
            Console.WriteLine("               Apellido: Cardona               ");
            Console.WriteLine("             Telefono: 3041268672              ");
            Console.WriteLine($"    Correo electrónico: DCardona10@gmail.com  ");
            Console.WriteLine("                Estado: Activo                 ");
            Console.WriteLine("===============================================");
        }
        else
        {
            Console.WriteLine("Has ingresado una respuesta invalida. Intentalo nuevamente.");
        }

        Console.Write("presiona Enter para continuar... ");
        Console.ReadLine();
    }

    static void MenuReportes()
    {
        int opciones_reportes;
        do
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("     Menú de reportes    ");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Préstamo por usuario.");
            Console.WriteLine("2. Préstamo por libro.");
            Console.WriteLine("3. Préstamo vencidos.");
            Console.WriteLine("4. Resumen general.");
            Console.WriteLine("5. Volver al menú de búqueda y reportes.");
            Console.Write("Señor usuario ingresa la opción que desea ingresar: ");
            opciones_reportes = int.Parse(Console.ReadLine() ?? "0");

            switch (opciones_reportes)
            {
                case 1:
                    //Función para un reporte de un préstamo por usuario
                    ReportePorUsuario();
                    break;

                case 2:
                    //Función para un reporte de un préstamo por libro
                    ReportePorLibro();
                    break;
                
                case 3: 
                    //Función para un reporte de un préstamo vencido(pasado la fecha limite)
                    ReportePrestamoVencido();
                    break;

                case 4:    
                    //Función para un reporte para dar un resumen general:total libros/disponibles y prestados
                    ResumenGeneral();
                    break;

                case 5:
                    Console.WriteLine("Volviendo al menu de búsqueda y reportes... ");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;
                
                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente.");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;
            }
        } while (opciones_reportes != 5);
    }

    static void ReportePorUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== Buscar reporte de préstamo por usuario ===");
        Console.Write("Señor usuario ingrese el id/documento del usuario: ");
        string id_usuario = Console.ReadLine() ?? "";

        Console.Clear();
        Console.WriteLine($"Buscando préstamos por usuario con el id/documento: {id_usuario}...");
        Console.WriteLine($"Préstamos encontrados del usuario con el id/documento: {id_usuario} exitosamente.✅ \nCreando reporte....");
        Console.WriteLine("=============================== Reporte por préstamo por usuario ========================================");
        Console.WriteLine("ID Préstamo   ID Usuario    ID/ISBN Libro   Fecha Préstamo   Fecha Límite  Fecha Devolución   Estado   ");
        Console.WriteLine($"  P-050         {id_usuario}       978-1-23        2024-01-10       2024-06-24         null          Activo   ");
        Console.WriteLine($"  P-065         {id_usuario}       978-3-16        2024-02-05       2024-08-19      2024-08-10       Cerrado  ");
        Console.WriteLine($"  P-080         {id_usuario}       978-4-56        2024-03-01       2024-11-15         null          Activo   ");
        Console.WriteLine("==========================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ReportePorLibro()
    {
        Console.Clear();
        Console.WriteLine("=== Buscar reporte de préstamo por libro ===");
        Console.Write("Señor usuario ingrese el id/ISBN del libro: ");
        string id_libro = Console.ReadLine() ?? "";

        Console.Clear();
        Console.WriteLine($"Buscando préstamos por libro con el ID/ISBN: {id_libro}...");
        Console.WriteLine($"Préstamos encontrados del libro con el ID/ISBN: {id_libro} exitosamente.✅ \nCreando reporte....");
        Console.WriteLine("=============================== Reporte por préstamo por libro ========================================");
        Console.WriteLine("ID Préstamo   ID Usuario    ID/ISBN Libro   Fecha Préstamo   Fecha Límite  Fecha Devolución   Estado   ");
        Console.WriteLine($"  P-050         101325686      {id_libro}        2024-01-10       2024-06-24         null          Activo   ");
        Console.WriteLine($"  P-065         974-6-321      {id_libro}        2024-02-05       2024-08-19      2024-08-10       Cerrado  ");
        Console.WriteLine($"  P-080         998-8-451      {id_libro}        2024-03-01       2024-11-15         null          Activo   ");
        Console.WriteLine("==========================================================================================================");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ReportePrestamoVencido()
    {
        Console.Clear();
        Console.WriteLine("==================== Reporte de préstamo vencidos ==============");
        Console.WriteLine("ID Préstamo   ID Usuario   Fecha Límite   Días vencido   Estado");
        Console.WriteLine("P-007         978-3-16     2024-01-24     45 días        Activo");
        Console.WriteLine("P-015         916-5-61     2024-03-10     30 días        Activo");
        Console.WriteLine("P-039         935-8-91     2024-05-18     15 días        Activo");
        Console.WriteLine("================================================================");
        Console.WriteLine("\n>>> Se listarían todos los préstamos vencidos del sistema.");
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ResumenGeneral()
    {
        Console.Clear();
        Console.WriteLine("===== Resumen general: total libros/disponibles/prestados =====");
        Console.WriteLine("                  Total libros registrados: 10                 ");
        Console.WriteLine("                     Libros disponibles: 7                     ");
        Console.WriteLine("                      Libros prestados: 3                      ");
        Console.WriteLine("                       Total usuarios: 15                      ");
        Console.WriteLine("                      Usuarios activos: 12                     ");
        Console.WriteLine("                       Total préstamos: 20                     ");
        Console.WriteLine("                      Préstamos activos: 3                     ");
        Console.WriteLine("                      Préstamos cerrados: 17                   ");
        Console.WriteLine("===============================================================");
        Console.Write("Presiona Enter para continuar... ");
        Console.ReadLine();
    }
    static void MostrarMenuGuardarCargarDatos()
    {
        int menu_datos;
        do
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("  Menú Cuardar/Cargar Datos ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Guardar datos(libros/usuarios/préstamos).");
            Console.WriteLine("2. Cargar Datos.");
            Console.WriteLine("3. Reiniciar Datos.");
            Console.WriteLine("4. Volver al menú principal.");
            Console.Write("Elija una de las opciones a la que desea ingresar: ");
            menu_datos = int.Parse(Console.ReadLine() ?? "0");

            switch (menu_datos)
            {
                case 1:
                    //Funcion para Guardar datos de libros,usuarios y préstamos
                    GuardarDatos();
                    break;

                case 2:
                    //Funcion para cargar datos
                    CargarDatos();
                    break;

                case 3:
                    //Funcion para reiniciar datos (vaciar todo y pedir confirmación
                    ReiniciarDatos();
                    break;

                case 4:
                    Console.WriteLine("Volviendo al menú principal...");
                    Console.Write("Presiona Enter para continuar... ");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción invalida. Intentalo nuevamente");
                    Console.Write("\nPresiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (menu_datos != 4);   
    }

    static void GuardarDatos()
    {
        Console.Clear();
        Console.WriteLine("=== Guardar datos de usuarios,libros y préstamos ===");
        Console.WriteLine("Se estan guardando los libros...");
        Console.WriteLine("Guardando los usuarios...");
        Console.WriteLine("Guardando los préstamos...");
        Console.WriteLine("Se guardo todos los datos con éxito.✅");
        Console.Write("Presiona Enter para continuar... ");
        Console.ReadLine();
    }

    static void CargarDatos()
    {
        Console.Clear();
        Console.WriteLine("=== Cargar datos ===");
        Console.WriteLine("Cargando los datos de libros");
        Console.WriteLine("Cargando los datos de usuarios");
        Console.WriteLine("Cargando los datos de préstamos");
        Console.WriteLine("Se completo la carga de los datos exitosamente.✅");
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ReiniciarDatos()
    {
        Console.Clear();
        Console.WriteLine("=== Reiniciar todos los datos ===");
        Console.WriteLine("Señor usuario ¿quieres reiniciar todos los datos(usuarios,libros y préstamos)(si/no)?");
        string confirmacion = Console.ReadLine() ?? "";

        if(confirmacion.ToLower() == "si")
        {
            Console.WriteLine("Reiniciando datos");
            Console.WriteLine("se reiniciaron exitosamente todos los datos.✅");
        }
        else if(confirmacion.ToLower() == "no")
        {
            Console.WriteLine("Cancelando el reinicio de datos...");
            Console.WriteLine("Se cancelo El reinicio de los datos.❌");
        }
        else
        {
            Console.WriteLine("Se cancelo el reinicio de los datos, ya que ingreso una opción invalida.");
        }
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
    }
}
