using Aladin.Domain;
using Aladin.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aladin.Data
{
    public class AppPlanningContext : IdentityDbContext
    {
        public AppPlanningContext()
        {
            //Database.EnsureCreated();
        }

        public AppPlanningContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Exemple> Exemples { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Demande> Demande { get; set; }
        public DbSet<Car> Car { get; set; }

        //public DbSet<Exemple> Exemples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=EventPlanner-DB;
            Integrated Security=true;
            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
