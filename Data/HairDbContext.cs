using HairSalon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HairSalon.Data
{
    /// <summary>
    /// Database context for the Hair Salon application
    /// </summary>
    public class HairDbContext : IdentityDbContext
    {
        public HairDbContext(DbContextOptions<HairDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Appointments table
        /// </summary>
        public DbSet<Appointment> Appointments { get; set; } = null!;

        /// <summary>
        /// Legacy table - kept for backward compatibility
        /// </summary>
        public DbSet<HairSalonData> HairSalons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Appointment entity
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email);
            });

            // Configure legacy HairSalonData entity
            modelBuilder.Entity<HairSalonData>(entity =>
            {
                entity.ToTable("HairSalons");
                entity.HasKey(e => e.Id);
            });
        }
    }
}
