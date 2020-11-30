using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeliveryCoreServer.Models
{
    public partial class VideoGameDBContext : DbContext
    {
        public VideoGameDBContext()
        {
        }

        public VideoGameDBContext(DbContextOptions<VideoGameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Videogame> Videogames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-888A9C9\\SQLEXPRESS;DataBase=VideoGameDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("developer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("platform");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Videogame>(entity =>
            {

                entity.ToTable("videogame");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PlatformId).HasColumnName("platform_id");

                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

                entity.Property(e => e.DeveloperId).HasColumnName("developer_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.HasOne(d => d.Developer)
                    .WithMany()
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_videogame_developer");

                entity.HasOne(d => d.Platform)
                    .WithMany()
                    .HasForeignKey(d => d.PlatformId)
                    .HasConstraintName("FK_videogame_platform");

                entity.HasOne(d => d.Publisher)
                    .WithMany()
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_videogame_publisher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
