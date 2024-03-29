﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class BartersDBContext : DbContext
    {
        public BartersDBContext()
        {
        }

        public BartersDBContext(DbContextOptions<BartersDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryUser> CategoryUsers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CustomerInquiry> CustomerInquiries { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=BartersDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.BigPicture).HasColumnName("BIgPicture");

                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<CategoryUser>(entity =>
            {
                entity.ToTable("Category_User");

                entity.HasOne(d => d.Categoty)
                    .WithMany(p => p.CategoryUsers)
                    .HasForeignKey(d => d.CategotyId)
                    .HasConstraintName("FK__Category___Categ__11158940");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CategoryUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Category___UserI__10216507");
            });

            modelBuilder.Entity<CustomerInquiry>(entity =>
            {
                entity.Property(e => e.TurnDate).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerInquiries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CustomerI__UserI__0F2D40CE");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Manager");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageDate).HasColumnType("date");

                entity.HasOne(d => d.UserIdGivenNavigation)
                    .WithMany(p => p.MessageUserIdGivenNavigations)
                    .HasForeignKey(d => d.UserIdGiven)
                    .HasConstraintName("FK_Massages_Users1");

                entity.HasOne(d => d.UsreIdReceivedNavigation)
                    .WithMany(p => p.MessageUsreIdReceivedNavigations)
                    .HasForeignKey(d => d.UsreIdReceived)
                    .HasConstraintName("FK_Massages_Users");
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.ToTable("Opinion");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.HasOne(d => d.Drage)
                    .WithMany(p => p.OpinionDrages)
                    .HasForeignKey(d => d.DrageId)
                    .HasConstraintName("FK__Opinion__DrageId__0B5CAFEA");

                entity.HasOne(d => d.Graded)
                    .WithMany(p => p.OpinionGradeds)
                    .HasForeignKey(d => d.GradedId)
                    .HasConstraintName("FK__Opinion__GradedI__0C50D423");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication");

                entity.Property(e => e.ClosingDate).HasColumnType("date");

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.HasOne(d => d.UserIdPublishNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.UserIdPublish)
                    .HasConstraintName("FK__Publicati__UserI__09746778");
            });

            modelBuilder.Entity<Star>(entity =>
            {
                entity.Property(e => e.DateGiven).HasColumnType("date");

                entity.Property(e => e.DateReceived).HasColumnType("date");

                entity.HasOne(d => d.UserIdGivenNavigation)
                    .WithMany(p => p.StarUserIdGivenNavigations)
                    .HasForeignKey(d => d.UserIdGiven)
                    .HasConstraintName("FK__Stars__UserIdGiv__0D44F85C");

                entity.HasOne(d => d.UserIdReceivedNavigation)
                    .WithMany(p => p.StarUserIdReceivedNavigations)
                    .HasForeignKey(d => d.UserIdReceived)
                    .HasConstraintName("FK__Stars__UserIdRec__0E391C95");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Users__CityId__0697FACD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
