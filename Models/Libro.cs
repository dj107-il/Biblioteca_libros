

public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string IdIsbn { get; set; }
    public string Categoria { get; set; }
    public int AñoPublicacion { get; set; }
    public bool Disponible { get; set; }

    public Libro(string titulo, string autor, string idIsbn, string categoria, int añoPublicacion, bool disponible)
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.IdIsbn = idIsbn;
        this.Categoria = categoria;
        this.AñoPublicacion = añoPublicacion;
        this.Disponible = disponible;
    }

    public Libro()
    {
        Disponible = true;
    }

    public void ResumenCorto()
    {
Console.WriteLine($"[{IdIsbn}] - {Titulo} por {Autor} en {AñoPublicacion} | Categoría: {Categoria} | Disponible: {(Disponible ? "Sí" : "No")}");
    }

    public void DetalleCompleto() 
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"ISBN: {IdIsbn}");
        Console.WriteLine($"Categoría: {Categoria}");
        Console.WriteLine($"Año de Publicación: {AñoPublicacion}");
        Console.WriteLine($"Disponible: {(Disponible ? "Sí" : "No")}");

    }

    public override string ToString()
    {
        return $"[{IdIsbn}] {Titulo} - {Autor} | Disponible: {(Disponible ? "Sí" : "No")}";
    }
    
}