namespace GestionBiblioteca.BusinessLogic.Entidades;
public class Categoria
{
    public long IdCategoria { get; set; }
    public string? NombreCategoria { get; set; }
    public string? DescripcionCategoria { get; set; }
    // public List<SubCategorias> SubCategorias { get; set; }
    public List<Libro>? Libros { get; set; }
}