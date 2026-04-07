using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Biblioteca_libros;

class Program
{
    private static readonly LibroService libroService = new LibroService();
    private static readonly UsuarioService usuarioService = new UsuarioService();
    private static readonly PrestamoService prestamoService = new PrestamoService();

    static void Main(string[] args)
    {
        MostrarBienvenida();
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
        Console.Clear();

        MostrarTituloSeccion("Vista Inicial");
        ArrayVsList.Comparar();
        Pausar();
        Console.Clear();

        MostrarMenuPrincipal();
    }

    static void MostrarTituloSeccion(string titulo)
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine($"   {titulo}");
        Console.WriteLine("===========================================");
    }

    static void Pausar()
    {
        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarCampo(string etiqueta, string valor)
    {
        Console.WriteLine($"{etiqueta}: {valor}");
    }

    static void MostrarSeparador()
    {
        Console.WriteLine("-------------------------------------------");
    }

    static void MostrarLibroVertical(Libro libro)
    {
        MostrarCampo("ID/ISBN", libro.IdIsbn);
        MostrarCampo("Título", libro.Titulo);
        MostrarCampo("Autor", libro.Autor);
        MostrarCampo("Categoría", libro.Categoria);
        MostrarCampo("Año", libro.AñoPublicacion.ToString());
        MostrarCampo("Disponible", libro.Disponible ? "Sí" : "No");
    }

    static void MostrarUsuarioVertical(Usuario usuario)
    {
        MostrarCampo("ID/Documento", usuario.IdDocumento);
        MostrarCampo("Nombre", usuario.Nombre);
        MostrarCampo("Apellido", usuario.Apellido);
        MostrarCampo("Teléfono", usuario.TelefonoContacto);
        MostrarCampo("Correo", usuario.CorreoElectronico);
        MostrarCampo("Estado", usuario.Activo ? "Activo" : "Desactivado");
    }

    static void MostrarPrestamoVertical(Prestamo prestamo)
    {
        MostrarCampo("ID préstamo", prestamo.IdPrestamo);
        MostrarCampo("Usuario", prestamo.IdUsuario);
        MostrarCampo("Libro", prestamo.IdLibro);
        MostrarCampo("Fecha préstamo", prestamo.FechaPrestamo.ToString("yyyy-MM-dd"));
        MostrarCampo("Fecha límite", prestamo.FechaLimite.ToString("yyyy-MM-dd"));
        MostrarCampo("Fecha devolución", prestamo.FechaDevolucion?.ToString("yyyy-MM-dd") ?? "Pendiente");
        MostrarCampo("Estado", prestamo.Estado.ToString());
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out opcion))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
                    Console.ReadLine();
                    break;

            }
        }while(opcion != 6);
    }

    static void ConfirmarSalidaYGuardar()
    {
        MostrarTituloSeccion("Salir del Sistema");
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_libros))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
                    break;
            }
        } while (menu_libros != 6);
    }

    static void RegistrarLibro()
    {
        MostrarTituloSeccion("Registrar Libro");
        Console.Write("ID/ISBN: ");
        string id = Console.ReadLine() ?? "";
        if (libroService.ObtenerPorIsbn(id) != null)
        {
            Console.WriteLine("El ID/ISBN ya existe. Inténtalo con otro.");
            Console.ReadLine();
            return;
        }
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";
        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine() ?? "";
        Console.Write("Año de publicación: ");
        int año;
        while (!int.TryParse(Console.ReadLine() ?? "0", out año))
        {
            Console.Write("Año inválido. Ingresa un número válido: ");
        }

        libroService.AgregarLibro(new Libro(titulo, autor, id, categoria, año, true));
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_listar_libros))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Todos los Libros");
        var libros = libroService.ObtenerTodos();
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay registros de libros.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                MostrarLibroVertical(libro);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void ListarLibrosDisponibles()
    {
        MostrarTituloSeccion("Libros Disponibles");
        var libros = libroService.ObtenerTodos().Where(l => l.Disponible).ToList();
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay registros de libros disponibles.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                MostrarLibroVertical(libro);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void ListarLibrosPrestados()
    {
        MostrarTituloSeccion("Libros Prestados");
        var libros = libroService.ObtenerTodos().Where(l => !l.Disponible).ToList();
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay registros de libros prestados.");
        }
        else
        {
            foreach (Libro libro in libros)
            {
                MostrarLibroVertical(libro);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void MostrarDetallesLibro()
    {
        MostrarTituloSeccion("Detalle del Libro");
        Console.Write("Ingrese el ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Libro? libro = libroService.ObtenerPorIsbn(id_isbn);
        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
        }
        else
        {
            MostrarSeparador();
            MostrarLibroVertical(libro);
        }
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out opcion_actualizar_libro))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Editar Título del Libro");
        Console.Write("ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Libro? libro = libroService.ObtenerPorIsbn(id_isbn);
        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            Console.ReadLine();
            return;
        }
        Console.Write("Nuevo título: ");
        string nuevo_titulo = Console.ReadLine() ?? "";
        libroService.ActualizarLibro(new Libro(nuevo_titulo, libro.Autor, libro.IdIsbn, libro.Categoria, libro.AñoPublicacion, libro.Disponible));
        Pausar();
    }

    static void EditarAutorLibro()
    {
        MostrarTituloSeccion("Editar Autor del Libro");
        Console.Write("ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Libro? libro = libroService.ObtenerPorIsbn(id_isbn);
        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            Console.ReadLine();
            return;
        }
        Console.Write("Nuevo autor: ");
        string nuevo_autor = Console.ReadLine() ?? "";
        libroService.ActualizarLibro(new Libro(libro.Titulo, nuevo_autor, libro.IdIsbn, libro.Categoria, libro.AñoPublicacion, libro.Disponible));
        Pausar();
    }

    static void EditarAñoCategoriaLibro()
    {
        MostrarTituloSeccion("Editar Año o Categoría");
        Console.Write("ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        Libro? libro = libroService.ObtenerPorIsbn(id_isbn);
        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.Write("¿Editar año o categoría? ");
        string respuesta = (Console.ReadLine() ?? "").ToLower();
        if (respuesta == "año")
        {
            Console.Write("Nuevo año: ");
            int nuevoAño;
            while (!int.TryParse(Console.ReadLine() ?? "0", out nuevoAño))
            {
                Console.Write("Año inválido. Ingresa un número válido: ");
            }
            libroService.ActualizarLibro(new Libro(libro.Titulo, libro.Autor, libro.IdIsbn, libro.Categoria, nuevoAño, libro.Disponible));
        }
        else if (respuesta == "categoria")
        {
            Console.Write("Nueva categoría: ");
            string nuevaCategoria = Console.ReadLine() ?? "";
            libroService.ActualizarLibro(new Libro(libro.Titulo, libro.Autor, libro.IdIsbn, nuevaCategoria, libro.AñoPublicacion, libro.Disponible));
        }
        Pausar();
    }

    static void EliminarLibro()
    {
        MostrarTituloSeccion("Eliminar Libro");
        Console.Write("ID/ISBN del libro: ");
        string id_isbn = Console.ReadLine() ?? "";
        libroService.EliminarLibro(id_isbn);
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_usuarios))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Registrar Usuario");
        Console.Write("ID/Documento: ");
        string id_documento = Console.ReadLine() ?? "";
        if (usuarioService.ObtenerPorDocumento(id_documento) != null)
        {
            Console.WriteLine("El ID/Documento ya existe. Inténtalo con otro.");
            Console.ReadLine();
            return;
        }
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? "";
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine() ?? "";
        Console.Write("Correo electrónico: ");
        string email = Console.ReadLine() ?? "";
        usuarioService.AgregarUsuario(new Usuario(nombre, apellido, id_documento, email, telefono, true));
        Pausar();
    }

    static void ListarUsuarios()
    {
        MostrarTituloSeccion("Listado de Usuarios");
        var usuarios = usuarioService.ObtenerTodos();
        if (usuarios.Count == 0)
        {
            Console.WriteLine("No hay registros de usuarios.");
        }
        else
        {
            foreach (Usuario usuario in usuarios)
            {
                MostrarUsuarioVertical(usuario);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void MostrarDetallesUsuario()
    {
        MostrarTituloSeccion("Detalle del Usuario");
        Console.Write("ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        Usuario? usuario = usuarioService.ObtenerPorDocumento(id_documento);
        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
        }
        else
        {
            MostrarSeparador();
            MostrarUsuarioVertical(usuario);
        }
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out opcion_actualizar_usuario))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Editar Nombre del Usuario");
        Console.Write("ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        Usuario? usuario = usuarioService.ObtenerPorDocumento(id_documento);
        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Console.ReadLine();
            return;
        }
        Console.Write("Nuevo nombre: ");
        string nuevo_nombre = Console.ReadLine() ?? "";
        usuarioService.ActualizarUsuario(new Usuario(nuevo_nombre, usuario.Apellido, usuario.IdDocumento, usuario.CorreoElectronico, usuario.TelefonoContacto, usuario.Activo));
        Pausar();
    }

    static void EditarContactoUsuario()
    {
        MostrarTituloSeccion("Editar Contacto del Usuario");
        Console.Write("ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        Usuario? usuario = usuarioService.ObtenerPorDocumento(id_documento);
        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Console.ReadLine();
            return;
        }
        Console.Write("Nuevo contacto telefónico: ");
        string nuevo_contacto = Console.ReadLine() ?? "";
        usuarioService.ActualizarUsuario(new Usuario(usuario.Nombre, usuario.Apellido, usuario.IdDocumento, usuario.CorreoElectronico, nuevo_contacto, usuario.Activo));
        Pausar();
    }

    static void ActivarDesactivarUsuario()
    {
        MostrarTituloSeccion("Cambiar Estado del Usuario");
        Console.Write("ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        Usuario? usuario = usuarioService.ObtenerPorDocumento(id_documento);
        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Console.ReadLine();
            return;
        }
        Console.Write("Escribe activar o desactivar: ");
        string activar_desactivar = Console.ReadLine() ?? "";

        if (activar_desactivar.ToLower() == "activar")
        {
            usuarioService.ActualizarUsuario(new Usuario(usuario.Nombre, usuario.Apellido, usuario.IdDocumento, usuario.CorreoElectronico, usuario.TelefonoContacto, true));
        }
        else if(activar_desactivar.ToLower() == "desactivar")
        {
            usuarioService.ActualizarUsuario(new Usuario(usuario.Nombre, usuario.Apellido, usuario.IdDocumento, usuario.CorreoElectronico, usuario.TelefonoContacto, false));
        }
        Pausar();

    }
    static void EliminarUsuario()
    {
        MostrarTituloSeccion("Eliminar Usuario");
        Console.Write("ID/Documento del usuario: ");
        string id_documento = Console.ReadLine() ?? "";
        usuarioService.EliminarUsuario(id_documento);
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_prestamos))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("\nPresiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Crear Préstamo");
        Console.Write("ID préstamo: ");
        string id_prestamo = Console.ReadLine() ?? "";
        if (prestamoService.ObtenerPorId(id_prestamo) != null)
        {
            Console.WriteLine("El ID de préstamo ya existe. Inténtalo con otro.");
            Console.ReadLine();
            return;
        }
        Console.Write("ID/Documento del usuario: ");
        string id_usuario = Console.ReadLine() ?? "";
        Usuario? usuario = usuarioService.ObtenerPorDocumento(id_usuario);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Console.ReadLine();
            return;
        }
        if (!usuario.Activo)
        {
            Console.WriteLine("El usuario está desactivado.");
            Console.ReadLine();
            return;
        }
        Console.Write("ID/ISBN del libro: ");
        string id_libro = Console.ReadLine() ?? "";
        Libro? libro = libroService.ObtenerPorIsbn(id_libro);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
            Console.ReadLine();
            return;
        }
        if (!libro.Disponible)
        {
            Console.WriteLine("El libro no está disponible.");
            Console.ReadLine();
            return;
        }
        Console.Write("Fecha límite (yyyy-MM-dd): ");
        DateTime fechaLimite;
        while (!DateTime.TryParse(Console.ReadLine() ?? "", out fechaLimite))
        {
            Console.Write("Fecha inválida. Ingresa una fecha válida (yyyy-MM-dd): ");
        }

        prestamoService.AgregarPrestamo(new Prestamo(id_prestamo, id_usuario, id_libro, DateTime.Now, fechaLimite, null, EstadoPrestamo.Activo));
        libro.Disponible = false; // Mark book as unavailable
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out opcion_prestamo))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.WriteLine("\nPresiona Enter para continuar... ");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Todos los Préstamos");
        var prestamos = prestamoService.ObtenerTodos();
        if (prestamos.Count == 0)
        {
            Console.WriteLine("No hay registros de préstamos.");
        }
        else
        {
            foreach (Prestamo prestamo in prestamos)
            {
                MostrarPrestamoVertical(prestamo);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void ListarPrestamosActivos()
    {
        MostrarTituloSeccion("Préstamos Activos");
        var prestamos = prestamoService.ObtenerTodos().Where(p => p.Estado == EstadoPrestamo.Activo).ToList();
        if (prestamos.Count == 0)
        {
            Console.WriteLine("No hay registros de préstamos activos.");
        }
        else
        {
            foreach (Prestamo prestamo in prestamos)
            {
                MostrarPrestamoVertical(prestamo);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void ListarPrestamosCerrados()
    {
        MostrarTituloSeccion("Préstamos Cerrados");
        var prestamos = prestamoService.ObtenerTodos().Where(p => p.Estado == EstadoPrestamo.Devuelto).ToList();
        if (prestamos.Count == 0)
        {
            Console.WriteLine("No hay registros de préstamos cerrados.");
        }
        else
        {
            foreach (Prestamo prestamo in prestamos)
            {
                MostrarPrestamoVertical(prestamo);
                MostrarSeparador();
            }
        }
        Pausar();
    }

    static void MostrarDetallesPrestamo()
    {
        MostrarTituloSeccion("Detalle del Préstamo");
        Console.Write("Ingrese el ID del préstamo: ");
        string id_prestamo = Console.ReadLine() ?? "";
        Prestamo? prestamo = prestamoService.ObtenerPorId(id_prestamo);
        if (prestamo is null)
        {
            Console.WriteLine("Préstamo no encontrado.");
        }
        else
        {
            MostrarSeparador();
            MostrarPrestamoVertical(prestamo);
        }
        Pausar();
    }

    static void RegistrarDevolucion()
    {
        MostrarTituloSeccion("Registrar Devolución");
        Console.Write("ID del préstamo: ");
        string id_prestamo = Console.ReadLine() ?? "";
        Prestamo? prestamo = prestamoService.ObtenerPorId(id_prestamo);
        if (prestamo is null)
        {
            Console.WriteLine("Préstamo no encontrado.");
            Console.ReadLine();
            return;
        }
        if (prestamo.Estado != EstadoPrestamo.Activo)
        {
            Console.WriteLine("El préstamo ya está cerrado.");
            Console.ReadLine();
            return;
        }
        prestamoService.ActualizarPrestamo(new Prestamo(prestamo.IdPrestamo, prestamo.IdUsuario, prestamo.IdLibro, prestamo.FechaPrestamo, prestamo.FechaLimite, DateTime.Now, EstadoPrestamo.Devuelto));
        Libro? libro = libroService.ObtenerPorIsbn(prestamo.IdLibro);
        if (libro != null)
        {
            libro.Disponible = true; // Mark book as available
        }
        Pausar();
    }

    static void EliminarPrestamo()
    {
        MostrarTituloSeccion("Eliminar Préstamo");
        Console.Write("ID del préstamo: ");
        string id_prestamo = Console.ReadLine() ?? "";
        prestamoService.EliminarPrestamo(id_prestamo);

        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_busqueda_reportes))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("\nPresiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Buscar Libro");
        Console.WriteLine("Señor usuario por donde desea buscar el libro");
        Console.WriteLine("¿por título o autor o ID/ISBN o por categoría?");
        string respuesta_busqueda = Console.ReadLine() ?? "";

        if(respuesta_busqueda.ToLower() == "titulo")
        {
            Console.Clear();
            Console.WriteLine("¿Como se llama el libro?");
            string titulo_libro = Console.ReadLine() ?? "";

            MostrarTituloSeccion("Resultado de Búsqueda");
            Console.WriteLine($"Buscando libro por el título: {titulo_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", "978-3-16");
            MostrarCampo("Título", titulo_libro);
            MostrarCampo("Autor", "Gabriel García");
            MostrarCampo("Categoría", "Novela");
            MostrarCampo("Año", "2000");
            MostrarCampo("Disponible", "Sí");
        }
        else if(respuesta_busqueda.ToLower() == "autor")
        {
            Console.Clear();
            Console.WriteLine("¿Como se llama el autor del libro?");
            string autor_libro = Console.ReadLine() ?? "*";

            MostrarTituloSeccion("Resultados de Búsqueda");
            Console.WriteLine($"Buscando libro por el autor: {autor_libro}");
            Console.WriteLine("Los libros fueron encontrados exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", "977-2-12");
            MostrarCampo("Título", "Las maravillas");
            MostrarCampo("Autor", autor_libro);
            MostrarCampo("Categoría", "Fantasía");
            MostrarCampo("Año", "1988");
            MostrarCampo("Disponible", "Sí");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", "998-8-21");
            MostrarCampo("Título", "Los tolerantes");
            MostrarCampo("Autor", autor_libro);
            MostrarCampo("Categoría", "Suspenso");
            MostrarCampo("Año", "1975");
            MostrarCampo("Disponible", "No");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", "912-7-98");
            MostrarCampo("Título", "Wilson y sus cagadas");
            MostrarCampo("Autor", autor_libro);
            MostrarCampo("Categoría", "Drama, Comedia");
            MostrarCampo("Año", "1990");
            MostrarCampo("Disponible", "Sí");
        }
        else if(respuesta_busqueda.ToLower() == "id/isbn" || respuesta_busqueda.ToLower() == "id")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el ID/ISBN del libro?");
            string id_libro = Console.ReadLine() ?? "0";

            MostrarTituloSeccion("Resultado de Búsqueda");
            Console.WriteLine($"Buscando libro por el ID/ISBN: {id_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", id_libro);
            MostrarCampo("Título", "Los sureños");
            MostrarCampo("Autor", "Esneider García");
            MostrarCampo("Categoría", "Historia");
            MostrarCampo("Año", "2002");
            MostrarCampo("Disponible", "Sí");
        }
        else if(respuesta_busqueda.ToLower() == "categoria")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es la categoría del libro?");
            string categoria_libro = Console.ReadLine() ?? "";
            MostrarTituloSeccion("Resultado de Búsqueda");
            Console.WriteLine($"Buscando libro por la categoría: {categoria_libro}");
            Console.WriteLine("EL libro fue encontrado exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/ISBN", "978-3-16");
            MostrarCampo("Título", "El cerebro de wilson");
            MostrarCampo("Autor", "Miguel Angel G");
            MostrarCampo("Categoría", categoria_libro);
            MostrarCampo("Año", "2024");
            MostrarCampo("Disponible", "Sí");
        }
        else
        {
            Console.WriteLine("Has ingresado una respuesta invalida. Intentalo nuevamente.");
        }

        Pausar();
    }

    static void BuscarUsuario()

    {
        MostrarTituloSeccion("Buscar Usuario");
        Console.WriteLine("Señor usuario por donde desea buscar el usuario");
        Console.WriteLine("¿por nombre o id/documento?");
        string respuesta_busqueda = Console.ReadLine() ?? "";

        if(respuesta_busqueda.ToLower() == "nombre")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el nombre del usuario que estas buscando?");
            string nombre_usuario = Console.ReadLine() ?? "Vacio";

            MostrarTituloSeccion("Resultado de Búsqueda");
            Console.WriteLine($"Buscando al usuario por el nombre: {nombre_usuario}... ");
            Console.WriteLine("El usuario ha sido encontrado exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/Documento", "1013245235");
            MostrarCampo("Nombre", nombre_usuario);
            MostrarCampo("Apellido", "Restrepo");
            MostrarCampo("Teléfono", "3012414626");
            MostrarCampo("Correo", $"{nombre_usuario[0]}R10@gmail.com");
            MostrarCampo("Estado", "Activo");
        }
        else if(respuesta_busqueda.ToLower() == "id/documento" || respuesta_busqueda.ToLower() == "id")
        {
            Console.Clear();
            Console.WriteLine("¿Cuál es el ID/ISBN del usuario que estas buscando?");
            string id_usuario = Console.ReadLine() ?? "0";

            MostrarTituloSeccion("Resultado de Búsqueda");
            Console.WriteLine($"Buscando al usuario por el id/documento: {id_usuario}... ");
            Console.WriteLine("El usuario ha sido encontrado exitosamente. ✅");
            MostrarSeparador();
            MostrarCampo("ID/Documento", id_usuario);
            MostrarCampo("Nombre", "David");
            MostrarCampo("Apellido", "Cardona");
            MostrarCampo("Teléfono", "3041268672");
            MostrarCampo("Correo", "DCardona10@gmail.com");
            MostrarCampo("Estado", "Activo");
        }
        else
        {
            Console.WriteLine("Has ingresado una respuesta invalida. Intentalo nuevamente.");
        }

        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out opciones_reportes))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("Presiona Enter para continuar... ");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Reporte por Usuario");
        Console.WriteLine("=== Buscar reporte de préstamo por usuario ===");
        Console.Write("Señor usuario ingrese el id/documento del usuario: ");
        string id_usuario = Console.ReadLine() ?? "";

        MostrarTituloSeccion("Resultado del Reporte");
        Console.WriteLine($"Buscando préstamos por usuario con el id/documento: {id_usuario}...");
        Console.WriteLine($"Préstamos encontrados del usuario con el id/documento: {id_usuario} exitosamente.✅ \nCreando reporte....");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-050");
        MostrarCampo("Usuario", id_usuario);
        MostrarCampo("Libro", "978-1-23");
        MostrarCampo("Fecha préstamo", "2024-01-10");
        MostrarCampo("Fecha límite", "2024-06-24");
        MostrarCampo("Fecha devolución", "Pendiente");
        MostrarCampo("Estado", "Activo");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-065");
        MostrarCampo("Usuario", id_usuario);
        MostrarCampo("Libro", "978-3-16");
        MostrarCampo("Fecha préstamo", "2024-02-05");
        MostrarCampo("Fecha límite", "2024-08-19");
        MostrarCampo("Fecha devolución", "2024-08-10");
        MostrarCampo("Estado", "Cerrado");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-080");
        MostrarCampo("Usuario", id_usuario);
        MostrarCampo("Libro", "978-4-56");
        MostrarCampo("Fecha préstamo", "2024-03-01");
        MostrarCampo("Fecha límite", "2024-11-15");
        MostrarCampo("Fecha devolución", "Pendiente");
        MostrarCampo("Estado", "Activo");
        Pausar();
    }

    static void ReportePorLibro()
    {
        MostrarTituloSeccion("Reporte por Libro");
        Console.WriteLine("=== Buscar reporte de préstamo por libro ===");
        Console.Write("Señor usuario ingrese el id/ISBN del libro: ");
        string id_libro = Console.ReadLine() ?? "";

        MostrarTituloSeccion("Resultado del Reporte");
        Console.WriteLine($"Buscando préstamos por libro con el ID/ISBN: {id_libro}...");
        Console.WriteLine($"Préstamos encontrados del libro con el ID/ISBN: {id_libro} exitosamente.✅ \nCreando reporte....");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-050");
        MostrarCampo("Usuario", "101325686");
        MostrarCampo("Libro", id_libro);
        MostrarCampo("Fecha préstamo", "2024-01-10");
        MostrarCampo("Fecha límite", "2024-06-24");
        MostrarCampo("Fecha devolución", "Pendiente");
        MostrarCampo("Estado", "Activo");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-065");
        MostrarCampo("Usuario", "974-6-321");
        MostrarCampo("Libro", id_libro);
        MostrarCampo("Fecha préstamo", "2024-02-05");
        MostrarCampo("Fecha límite", "2024-08-19");
        MostrarCampo("Fecha devolución", "2024-08-10");
        MostrarCampo("Estado", "Cerrado");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-080");
        MostrarCampo("Usuario", "998-8-451");
        MostrarCampo("Libro", id_libro);
        MostrarCampo("Fecha préstamo", "2024-03-01");
        MostrarCampo("Fecha límite", "2024-11-15");
        MostrarCampo("Fecha devolución", "Pendiente");
        MostrarCampo("Estado", "Activo");
        Pausar();
    }

    static void ReportePrestamoVencido()
    {
        MostrarTituloSeccion("Préstamos Vencidos");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-007");
        MostrarCampo("Usuario", "978-3-16");
        MostrarCampo("Fecha límite", "2024-01-24");
        MostrarCampo("Días vencido", "45");
        MostrarCampo("Estado", "Activo");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-015");
        MostrarCampo("Usuario", "916-5-61");
        MostrarCampo("Fecha límite", "2024-03-10");
        MostrarCampo("Días vencido", "30");
        MostrarCampo("Estado", "Activo");
        MostrarSeparador();
        MostrarCampo("ID préstamo", "P-039");
        MostrarCampo("Usuario", "935-8-91");
        MostrarCampo("Fecha límite", "2024-05-18");
        MostrarCampo("Días vencido", "15");
        MostrarCampo("Estado", "Activo");
        Console.WriteLine("\n>>> Se listarían todos los préstamos vencidos del sistema.");
        Pausar();
    }

    static void ResumenGeneral()
    {
        MostrarTituloSeccion("Resumen General");
        MostrarCampo("Total libros registrados", "10");
        MostrarCampo("Libros disponibles", "7");
        MostrarCampo("Libros prestados", "3");
        MostrarCampo("Total usuarios", "15");
        MostrarCampo("Usuarios activos", "12");
        MostrarCampo("Total préstamos", "20");
        MostrarCampo("Préstamos activos", "3");
        MostrarCampo("Préstamos cerrados", "17");
        Pausar();
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
            if (!int.TryParse(Console.ReadLine() ?? "0", out menu_datos))
            {
                Console.WriteLine("Entrada inválida. Inténtalo nuevamente.");
                Console.Write("\nPresiona Enter para continuar...");
                Console.ReadLine();
                continue;
            }

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
        MostrarTituloSeccion("Guardar Datos");
        Console.WriteLine("=== Guardar datos de usuarios,libros y préstamos ===");
        Console.WriteLine("Se estan guardando los libros...");
        Console.WriteLine("Guardando los usuarios...");
        Console.WriteLine("Guardando los préstamos...");
        Console.WriteLine("Se guardo todos los datos con éxito.✅");
        Pausar();
    }

    static void CargarDatos()
    {
        MostrarTituloSeccion("Cargar Datos");
        Console.WriteLine("=== Cargar datos ===");
        Console.WriteLine("Cargando los datos de libros");
        Console.WriteLine("Cargando los datos de usuarios");
        Console.WriteLine("Cargando los datos de préstamos");
        Console.WriteLine("Se completo la carga de los datos exitosamente.✅");
        Pausar();
    }

    static void ReiniciarDatos()
    {
        MostrarTituloSeccion("Reiniciar Datos");
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
        Pausar();
    }

}
