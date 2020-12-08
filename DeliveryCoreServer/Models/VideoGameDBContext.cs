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

        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<VideoGames> VideoGames { get; set; }

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
            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.ToTable("publishers");

                entity.HasKey(e => e.PublisherId)
                    .HasName("PK_publishers");
                    

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.HasMany(e => e.VideoGames)
                    .WithOne(d => d.Publisher);
 
            });

            modelBuilder.Entity<VideoGames>(entity =>
            {

                entity.ToTable("videogames");

                entity.HasKey(e => e.VideoGameId)
                    .HasName("PK_videogames");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.HasOne(d => d.Publisher)
                    .WithMany(e => e.VideoGames)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_videogames_publishers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
