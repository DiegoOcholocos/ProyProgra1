using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using appproy.Models;

namespace appproy.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<appproy.Models.Contacto> DataContactos { get; set; }

    public DbSet<appproy.Models.Producto> DataProductos { get; set; }

}
