namespace GestionBiblioteca.BusinessLogic.Entidades;
public class LibroCategoria
{
    public long IdLibroCategoria { get; set; }
    public long IdLibro { get; set; }
    public long IdCategoria { get; set; }
    public Libro? Libro { get; set; }
    public Categoria? Categoria { get; set; }
}