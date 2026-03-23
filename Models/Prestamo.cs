using System.Runtime.CompilerServices;
using Biblioteca_libros;

class Prestamo
{
    public string IdPrestamo { get; set; }
    public string IdUsuario {get; set; }
    public string IdLibro { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaLimite { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo(string idPrestamo, string idUsuario, string idLibro, DateTime fechaPrestamo, DateTime fechaLimite, DateTime? fechaDevolucion, EstadoPrestamo estado)
    {
        this.IdPrestamo = idPrestamo;
        this.IdUsuario = idUsuario;
        this.IdLibro = idLibro;
        this.FechaPrestamo = fechaPrestamo;
        this.FechaLimite = fechaLimite;
        this.FechaDevolucion = fechaDevolucion;
        this.Estado = estado;
    }

    public Prestamo()
    {
        Estado = EstadoPrestamo.Activo;
        FechaDevolucion = null;
    }

    public bool EstaVencido()
    {
        return DateTime.Now > FechaLimite && Estado == EstadoPrestamo.Activo;
    }

    public int DiasTranscurridos()
    {
        return (DateTime.Now - FechaPrestamo).Days;
    }

    public void ResumenCorto()
    {
        Console.WriteLine($"[{IdPrestamo}] | libro: {IdLibro} | Usuario: {IdUsuario} | Fecha de prestamo: {FechaPrestamo} | Fecha límite: {FechaLimite} | Estado: {Estado}");
    }

    public void DetalleCompleto()
    {
        Console.WriteLine($"ID del préstamo: {IdPrestamo} ");
        Console.WriteLine($"ID/ISBN del libro: {IdLibro}");
        Console.WriteLine($"ID/Documento del usuario: {IdUsuario}");
        Console.WriteLine($"Fecha de prestamo: {FechaPrestamo}");
        Console.WriteLine($"Fecha límite: {FechaLimite}");
        Console.WriteLine($"Fecha de devolución: {FechaDevolucion}");
        Console.WriteLine($"Estado del préstamo: {Estado}");
    }

    public override string ToString()
    {
        return $"[{IdPrestamo}] ID libro: {IdLibro} | ID usuario: {IdUsuario} | Fecha de préstamo: {FechaPrestamo} | Fecha Límite: {FechaLimite} | Estado: {Estado}";

    }

}