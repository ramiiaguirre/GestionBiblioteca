namespace GestionBiblioteca.BusinessLogic.Entidades;
public class LibroAutor
{
    public long IdLibroAutor { get; set; }
    public long IdLibro { get; set; }
    public long IdAutor { get; set; }
    public Libro? Libro { get; set; }
    public Autor? Autor { get; set; }
    
}