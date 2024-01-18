using Capitulo03.Models;
using Microsoft.EntityFrameworkCore;

namespace Capitulo03.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options) 
        { 
        }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
