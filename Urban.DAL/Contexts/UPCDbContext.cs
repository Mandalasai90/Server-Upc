using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urban.DAL.Models;

namespace Urban.DAL.Contexts
{
    public class UPCDbContext: DbContext
    {
        private readonly string _connectionString;
        private readonly DbContextOptions<UPCDbContext> upcdbContext;

        public UPCDbContext(DbContextOptions<UPCDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public UPCDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseNpgsql(_connectionString);
        }
        public DbSet<Services> Services { get; set; }
        public DbSet<ServiceProviders> ServiceProviders { get; set; }
        public DbSet<ServiceCategories> ServiceCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for ServiceProviders
            modelBuilder.Entity<ServiceProviders>()
                .HasKey(sp => sp.provider_id);

            // Configure relationship to User
            modelBuilder.Entity<ServiceProviders>()
                .HasOne(sp => sp.users)
                .WithMany(u => u.serviceProviders)  // User has a collection of ServiceProviders
                .HasForeignKey(sp => sp.user_id);

            // Configure relationship to ServiceCategories
            modelBuilder.Entity<ServiceProviders>()
                .HasOne(sp => sp.serviceCategories)
                .WithMany(sc => sc.serviceProviders)
                .HasForeignKey(sp => sp.service_category_id);

            // Configure relationship to Services
            modelBuilder.Entity<Services>()
                .HasOne(s => s.serviceProviders)
                .WithMany(sp => sp.services)
                .HasForeignKey(s => s.provider_id);
        }


    }
}
