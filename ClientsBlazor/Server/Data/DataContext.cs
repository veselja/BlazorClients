global using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ClientsBlazor.Shared;

namespace ClientsBlazor.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BlazorClients;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>().HasData(
                    new Klient
                    {
                        Id = 1,
                        Name = "Test",
                        SongName = "Test",
                        Instagram = "Test",
                        Orders = 1

                    },
                    new Klient
                    {
                        Id = 2,
                        Name = "Test02",
                        SongName = "Test02",
                        Instagram = "Test02",
                        Orders = 1

                    }
                    );

        }
        public DbSet<Klient> Clients => Set<Klient>();

    }
}
