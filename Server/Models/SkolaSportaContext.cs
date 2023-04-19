
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class SkolaSportaContext : DbContext 
    {
        public SkolaSportaContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Dete> Deca{get; set;}
        public DbSet<SkolaSporta> SkoleSporta{get; set;}
        public DbSet<Sport> sportovi{get; set;}

        public DbSet<Roditelj> Roditelji{get;set;}
        public DbSet<Spoj> DecaISportovi {get;set;}
    }
}