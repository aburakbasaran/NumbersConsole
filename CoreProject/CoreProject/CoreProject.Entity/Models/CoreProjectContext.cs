using Microsoft.EntityFrameworkCore;
using System;

namespace CoreProject.Entity.Models
{
    public partial  class CoreProjectContext:DbContext
    {
        public CoreProjectContext()
        {

        }

        public CoreProjectContext(DbContextOptions<CoreProjectContext> options)
            :base(options)
        {

        }

        public virtual DbSet<City> City { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CountryId).IsRequired();
                entity.HasOne(d => d.Country)
                   .WithMany(p => p.Citys)
                   .HasForeignKey(d => d.CountryId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CityId).IsRequired();
                entity.HasOne(d => d.City)
                   .WithMany(p => p.Districts)
                   .HasForeignKey(d => d.CityId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DistrictId).IsRequired();
                entity.HasOne(d => d.District)
                   .WithMany(p => p.Towns)
                   .HasForeignKey(d => d.DistrictId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
