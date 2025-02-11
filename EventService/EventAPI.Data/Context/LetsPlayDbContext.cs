﻿using EventAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Data.Context
{
    public partial class LetsPlayDbContext : DbContext
    {
        public LetsPlayDbContext(DbContextOptions<LetsPlayDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Userevent> Userevent { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.ParentCategoryId)
                    .HasName("IX_Categories_ParentCategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_Categories_Categories_ParentCategoryID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

            });
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_Events_CategoryID");

                entity.HasIndex(e => e.CityId)
                    .HasName("IX_Events_CityID");

                entity.HasIndex(e => e.UserCreatedById)
                    .HasName("IX_Events_UserCreatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserCreatedById).HasColumnName("UserCreatedByID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Events_Categories_CategoryID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Events_Cities_CityID");
                entity.HasOne(d => d.User).WithMany(p => p.Events).HasForeignKey(d => d.UserCreatedById).HasConstraintName("IX_Events_UserCreatedByID");

            });

            modelBuilder.Entity<Userevent>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EventId })
                    .HasName("PRIMARY");

                entity.ToTable("userevents");

                entity.HasIndex(e => e.EventId)
                    .HasName("IX_UserEvent_EventID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Userevent)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_UserEvent_Events_EventID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
