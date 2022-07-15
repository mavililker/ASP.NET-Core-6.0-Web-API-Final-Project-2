using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Models
{
    public partial class FINALContext : IdentityDbContext<AppUser>
    {
        public FINALContext()
        {
        }

        public FINALContext(DbContextOptions<FINALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerTrade> CustomerTrades { get; set; } = null!;
        public virtual DbSet<Trade> Trades { get; set; } = null!;

        public DbSet<AppUserTokens> AppUserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=FINAL;Username=postgres;Password=5369");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTrade>(entity =>
            {
                entity.ToTable("CustomerTrade");

                entity.Property(e => e.CustomerTradeId).HasColumnName("CustomerTradeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TradeId).HasColumnName("TradeID");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.CustomerTrades)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("CustomerTrade_TradeID_fkey");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.Property(e => e.TradeId).HasColumnName("TradeID");

                entity.Property(e => e.Service).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<AppUser>();
            //Add admin user by default.
            const string ADMIN_ID = "1";
            const string ROLE_ID = "1";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                Name = "Admin",
                SurName = "Admin",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = String.Empty,
                Role = "Admin"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            const string EDITOR_ID = "2";
            const string ROLE_ID2 = "2";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID2,
                Name = "Editor",
                NormalizedName = "Editor"
            });

            
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = EDITOR_ID,
                UserName = "editor@gmail.com",
                NormalizedUserName = "editor@gmail.com",
                Email = "editor@gmail.com",
                NormalizedEmail = "editor@gmail.com",
                Name = "Editor",
                SurName = "Editor",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = String.Empty,
                Role = "Editor"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID2,
                UserId = EDITOR_ID
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
