namespace GestionBiblioteca.BusinessLogic.Entidades;
public class Autor
{
    public long IdAutor { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Nacionalidad { get; set; }
    public IEnumerable<Libro>? Libros { get; set; }
}
