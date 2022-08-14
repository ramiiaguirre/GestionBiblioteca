namespace GestionBiblioteca.BusinessLogic.Entidades;
public class Idioma
{
    public long IdIdioma { get; set; }
    public string? NombreIdioma { get; set; }
    public List<Libro>? Libros { get; set; }
}