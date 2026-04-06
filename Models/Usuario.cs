public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string IdDocumento { get; set; }
    public string CorreoElectronico { get; set; }
    public string TelefonoContacto { get; set; }
    public bool Activo { get; set; }

    public Usuario(string nombre, string apellido, string idDocumento, string correoElectronico, string telefonoContacto, bool activo)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.IdDocumento = idDocumento;
        this.CorreoElectronico = correoElectronico;
        this.TelefonoContacto = telefonoContacto;
        this.Activo = activo;
    }

    public Usuario()
    {
        this.Activo = true;
    }

    public void ResumenCorto()
    {
        Console.WriteLine($"[{IdDocumento}] - {Nombre} {Apellido} | Correo: {CorreoElectronico} | Teléfono: {TelefonoContacto} | Activo: {(Activo ? "Sí" : "No")}");
    }

    public void DetalleCompleto()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellido: {Apellido}");
        Console.WriteLine($"ID/Documento usuario: {IdDocumento}");
        Console.WriteLine($"Correo Electrónico: {CorreoElectronico}");
        Console.WriteLine($"Teléfono de Contacto: {TelefonoContacto}");
        Console.WriteLine($"Activo: {(Activo ? "Sí" : "No")}");
    }

    public override string ToString()
    {
        return $"[{IdDocumento}] {Nombre} {Apellido} | Correo: {CorreoElectronico} | Teléfono: {TelefonoContacto} | Activo: {(Activo ? "Sí" : "No")}";
    }
}


