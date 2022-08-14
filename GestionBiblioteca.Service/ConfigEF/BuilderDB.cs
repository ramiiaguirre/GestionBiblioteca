using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace GestionBiblioteca.Service.ConfigEF;

public class BuilderDB
{
    public void CreateDataBase()
    {
        using (var context = new BibliotecaContext())
        {
            context.Database.EnsureCreated();
        }
    }    
}