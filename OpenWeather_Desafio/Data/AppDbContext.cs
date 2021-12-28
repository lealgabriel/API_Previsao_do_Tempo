using Microsoft.EntityFrameworkCore;
using System;

namespace OpenWeather_Desafio.Data
{


    public class AppDbContext : DbContext
    {
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            public DbSet<Cidade> Produtos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Cidade>()
                    .Property(p => p.Nome)
                    .HasMaxLength(80);

                modelBuilder.Entity<Cidade>()
                    .Property(p => p.Temp)
                    .HasPrecision(10, 2);

                modelBuilder.Entity<Cidade>()
                   .Property(p => p.TempMax)
                   .HasPrecision(10, 2);

                modelBuilder.Entity<Cidade>()
                   .Property(p => p.TempMin)
                   .HasPrecision(10, 2);


            modelBuilder.Entity<Cidade>().HasData(
                    new Cidade { Id = DateTime.Now, Nome = "Teste", Temp = 0.00, TempMin = 0.00, TempMax = 0.00});

            }

        
    }
}
