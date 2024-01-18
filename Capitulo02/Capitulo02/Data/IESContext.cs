using Capitulo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Capitulo02.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        { 
        
        }

        public DbSet<Departamento> Departamentos { get; set;}
    }
}
