using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CovidandCrashes.Models
{
    public partial class CCDBContext : DbContext
    {
        public CCDBContext()
        {
        }

        public CCDBContext(DbContextOptions<CCDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collision> Collisions { get; set; } = null!;
        public virtual DbSet<Covid> Covids { get; set; } = null!;
        public virtual DbSet<Crashtable> Crashtables { get; set; } = null!;
        public virtual DbSet<DateTable> DateTables { get; set; } = null!;
        public virtual DbSet<Intersection> Intersections { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI0GC6D;Database=CCDB;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server = MHOME\\DEVSQL;Database=CCDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collision>(entity =>
            {
                entity.ToTable("Collision");

                entity.Property(e => e.CollisionId).HasColumnName("Collision Id");

                entity.Property(e => e.Collision1)
                    .HasMaxLength(255)
                    .HasColumnName("Collision")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Covid>(entity =>
            {
                entity.ToTable("Covid");

                entity.Property(e => e.CovidId).HasColumnName("Covid Id");

                entity.Property(e => e.DateId).HasColumnName("Date Id");

                entity.Property(e => e.StateId).HasColumnName("State Id");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.Covids)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Covid_DateTable");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Covids)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Covid_State");
            });

            modelBuilder.Entity<Crashtable>(entity =>
            {
                entity.HasKey(e => e.CrashId);

                entity.ToTable("Crashtable");

                entity.Property(e => e.CrashId).HasColumnName("Crash Id");

                entity.Property(e => e.CollisionId).HasColumnName("Collision Id");

                entity.Property(e => e.DateId).HasColumnName("Date Id");

                entity.Property(e => e.IntersectionId).HasColumnName("Intersection Id");

                entity.Property(e => e.StateId).HasColumnName("State Id");

                entity.HasOne(d => d.Collision)
                    .WithMany(p => p.Crashtables)
                    .HasForeignKey(d => d.CollisionId)
                    .HasConstraintName("FK_Crashtable_Collision");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.Crashtables)
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK_Crashtable_DateTable");

                entity.HasOne(d => d.Intersection)
                    .WithMany(p => p.Crashtables)
                    .HasForeignKey(d => d.IntersectionId)
                    .HasConstraintName("FK_Crashtable_Intersection");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Crashtables)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Crashtable_State");
            });

            modelBuilder.Entity<DateTable>(entity =>
            {
                entity.HasKey(e => e.DateId);

                entity.ToTable("DateTable");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("Date Id");
            });

            modelBuilder.Entity<Intersection>(entity =>
            {
                entity.ToTable("Intersection");

                entity.Property(e => e.IntersectionId).HasColumnName("Intersection Id");

                entity.Property(e => e.Intersection1)
                    .HasMaxLength(255)
                    .HasColumnName("Intersection")
                    .IsFixedLength();
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateId).HasColumnName("State Id");

                entity.Property(e => e.State1)
                    .HasMaxLength(10)
                    .HasColumnName("State")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
