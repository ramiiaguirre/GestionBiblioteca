using Microsoft.EntityFrameworkCore;
using GestionBiblioteca.BusinessLogic.Entidades;
using Microsoft.Extensions.Configuration;

namespace GestionBiblioteca.Service.ConfigEF;
public class BibliotecaContext : DbContext
{
    #nullable disable
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Idioma> Idiomas { get; set; }
    public DbSet<LibroAutor> LibroAutor { get; set; }
    public DbSet<LibroCategoria> LibroCategoria { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cs = new ConfigurationBuilder().SetBasePath("C:/Users/Ramiro/Desarrollo/GestionBiblioteca/GestionBiblioteca.Service").AddJsonFile("appsettingsConnections.json").Build().GetConnectionString("csBiblioteca");
        optionsBuilder.UseNpgsql(cs);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(libro =>
        {
            libro.ToTable("Libro");
            libro.HasKey(l => l.IdLibro);
            libro.Property(l => l.Titulo).IsRequired();
            libro.Property(l => l.Descripcion).IsRequired(false);
            libro.Property(l => l.Año).IsRequired(false);
            libro.HasMany(l => l.Autores).WithMany(a => a.Libros).UsingEntity<LibroAutor>();
            libro.HasMany(l => l.Categorias).WithMany(c => c.Libros).UsingEntity<LibroCategoria>();
            libro.Property(l => l.IdIdioma_fk);
            libro.Property(l => l.Valoracion).IsRequired(false);            
        });

        modelBuilder.Entity<Autor>(autor =>
        {
            autor.ToTable("Autor");
            autor.HasKey(a => a.IdAutor);
            autor.Property(a => a.Nombre).IsRequired();
            autor.Property(a => a.Apellido).IsRequired();
            autor.Property(a => a.Nacionalidad).IsRequired(false);
            autor.HasMany(a => a.Libros).WithMany(l => l.Autores).UsingEntity<LibroAutor>();
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.IdCategoria);
            categoria.Property(c => c.NombreCategoria).IsRequired();
            categoria.Property(c => c.DescripcionCategoria).IsRequired(false);
            categoria.HasMany(c => c.Libros).WithMany(l => l.Categorias).UsingEntity<LibroCategoria>();
        });

        modelBuilder.Entity<Idioma>(idioma =>
        {
            idioma.HasKey(i => i.IdIdioma);
            idioma.HasMany(i => i.Libros).WithOne().HasForeignKey(i => i.IdIdioma_fk);
        });

        modelBuilder.Entity<LibroAutor>(libroAutor =>
        {
            libroAutor.HasKey(la => la.IdLibroAutor);
            libroAutor.HasOne(la => la.Libro).WithMany().HasForeignKey(la => la.IdLibro);
            libroAutor.HasOne(la => la.Autor).WithMany().HasForeignKey(la => la.IdAutor);
        });

        modelBuilder.Entity<LibroCategoria>(libroCat =>
        {
            libroCat.HasKey(lc => lc.IdLibroCategoria);
            libroCat.HasOne(lc => lc.Libro).WithMany().HasForeignKey(lc => lc.IdLibro);
            libroCat.HasOne(lc => lc.Categoria).WithMany().HasForeignKey(lc => lc.IdCategoria);
        });
       
    }    
}

