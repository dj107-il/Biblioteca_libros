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

        Console.Clear();
        Console.WriteLine("=====================================================");
        Console.WriteLine($"⏸  Mostrando los detalles del usuario               ⏸");
        Console.WriteLine($"⏸ ID/Documento: {id_documento.PadRight(36)}⏸");
        Console.WriteLine("⏸  Nombres: Juan Alejandro                          ⏸");
        Console.WriteLine("⏸  Apellidos: Vazquez loaisa                        ⏸");
        Console.WriteLine("⏸  Telefono: 3013191210                             ⏸");
        Console.WriteLine("⏸  Correo electrónico: JuanAlejandroV@gmail.com     ⏸");
        Console.WriteLine("⏸  Estado: Desactivo                                ⏸");
        Console.WriteLine("======================================================");
        Console.Write("\nPresiona Enter para continuar...           ");
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

        Console.Clear();
        Console.WriteLine("=====================================================");
        Console.WriteLine($"⏸  Mostrando los detalles del préstamo             ⏸");
        Console.WriteLine($"⏸  ID: {id_prestamo.PadRight(44)}⏸");
        Console.WriteLine("⏸  ID: Usuario: 978-3-16                           ⏸");
        Console.WriteLine("⏸  ID/ISBN Libro: 978-1-23                         ⏸");
        Console.WriteLine("⏸  Fecha préstamo: 2024-06-27                      ⏸");
        Console.WriteLine("⏸  Fecha limite: 2024-10-31                        ⏸");
        Console.WriteLine("⏸  Fecha devolución: 2024-10-27                    ⏸");
        Console.WriteLine("⏸  Estado: Activo                                  ⏸");
        Console.WriteLine("=====================================================");
        Console.Write("\nPresiona Enter para continuar...           ");
        Console.ReadLine();
    }

    //por actualizar...
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
    static void MostrarMenuBusquedaReportes(){}
    static void MostrarMenuGuardarCargarDatos(){}
}
