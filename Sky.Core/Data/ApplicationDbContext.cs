using Microsoft.EntityFrameworkCore;
using Sky.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sky.Core.Data {
    public class ApplicationDbContext : DbContext {
        public DbSet<OrderDetailDto> OrdersDetails { get; set; } // Таблица услуг.

        public DbSet<PortfolioDto> Portfolio { get; set; }  // Таблица с работами в портфолио.

        public DbSet<PortfolioDetailsDto> DetailsWorks { get; set; }    // Таблица с деталями работ.

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MultepleContextTable>()
            .HasKey(t => new { t.OrderId });

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.OrderDetailDto)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.PortfolioDto)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.PortfolioDetailsDto)
                .WithMany(s => s.MultepleContextTables);
        }
    }
}
