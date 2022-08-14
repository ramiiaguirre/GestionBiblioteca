namespace GestionBiblioteca.BusinessLogic.Entidades;
public class Libro
{
    public long IdLibro { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set;}
    public DateTime? Año { get; set; }
    public List<Autor>? Autores { get; set; }
    public List<Categoria>? Categorias { get; set; }
    public long IdIdioma_fk { get; set; }    
    public Valoracion? Valoracion { get; set; }
    // public Reseña Reseña { get; set; }
}

public enum Valoracion
{
    Horrible,
    Malo,
    Normal,
    Bueno,
    Excelente
}