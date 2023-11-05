using Asp_net_core_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp_net_core_mvc
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Zoo> Zoo { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;

        public DbSet<Ticket> Ticket { get; set; } = null!;

        public DbSet<Type_Animal> Type_Animal { get; set; } = null!;

        public DbSet<Worker> Worker { get; set; } = null!;

        public DbSet<Aviary> Aviary { get; set; } = null!;

        public DbSet<Animal> Animal { get; set; } = null!;



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zoo>().ToTable(t => t.HasCheckConstraint("Workers_Ammount", "[Workers_Ammount] > 0"));
            modelBuilder.Entity<Zoo>().ToTable(t => t.HasCheckConstraint("Aviary_Ammount", "[Aviary_Ammount] > 0"));
            modelBuilder.Entity<Ticket>().ToTable(t => t.HasCheckConstraint("Cost", "[Cost] > 0"));
            modelBuilder.Entity<Worker>().ToTable(t => t.HasCheckConstraint("Salary", "[Salary] > 4200"));
            modelBuilder.Entity<Aviary>().ToTable(t => t.HasCheckConstraint("Animals_ammount", "[Animals_ammount] > 0"));
            modelBuilder.Entity<Animal>().ToTable(t => t.HasCheckConstraint("Age", "[Age] > 0"));
            modelBuilder.Entity<Animal>().ToTable(t => t.HasCheckConstraint("Weight", "[Weight] > 0"));
            modelBuilder.Entity<Customer>(entity => { entity.HasIndex(e => e.Telephone_numer).IsUnique(); });

            modelBuilder.Entity<Zoo>().HasMany(e => e.Tickets).WithOne(e => e.Zoo);
            modelBuilder.Entity<Customer>().HasMany(e => e.Tickets).WithMany(e => e.Customers);
            modelBuilder.Entity<Worker>().HasMany(e => e.Aviaries).WithMany(e => e.Workers);
            modelBuilder.Entity<Aviary>().HasMany(e => e.Animals).WithOne(e => e.Aviary);

            modelBuilder.Entity<Zoo>().HasData(
                    new Zoo { Id = 1, Name = "12 month", Workers_Ammount = 2, Aviary_Ammount = 2 },
                    new Zoo { Id = 2, Name = "Kyiv", Workers_Ammount = 4,  Aviary_Ammount = 2 },
                    new Zoo { Id = 3, Name = "International", Workers_Ammount = 8,  Aviary_Ammount = 2 }
            );
        }

    }
}
