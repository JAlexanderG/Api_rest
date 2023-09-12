using Api_Empresa.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Empresa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<Empleados> Empleados { get; set; }
    }
}
