using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WeddingApp.models
{
    public partial class weddingContext : DbContext
    {
        public weddingContext()
        {
        }

        public weddingContext(DbContextOptions<weddingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeGroup> AgeGroups { get; set; }
        public virtual DbSet<FoodChoice> FoodChoices { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=weddingdb.c4oddmt5kli3.eu-west-2.rds.amazonaws.com;user=wedding;password=Wedding;database=wedding;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<AgeGroup>(entity =>
            {
                entity.HasKey(e => e.IdAgeGroup)
                    .HasName("PRIMARY");

                entity.ToTable("AgeGroup");

                entity.Property(e => e.IdAgeGroup)
                    .ValueGeneratedNever()
                    .HasColumnName("idAgeGroup");

                entity.Property(e => e.AgeGrouptext).HasColumnType("mediumtext");
            });

            modelBuilder.Entity<FoodChoice>(entity =>
            {
                entity.HasKey(e => e.IdFoodChoice)
                    .HasName("PRIMARY");

                entity.ToTable("FoodChoice");

                entity.Property(e => e.IdFoodChoice).HasColumnName("idFoodChoice");

                entity.Property(e => e.Course).HasColumnType("mediumtext");

                entity.Property(e => e.FoodChoiceText).HasColumnType("mediumtext");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.IdGuests)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdGuests).HasColumnName("idGuests");

                entity.Property(e => e.AgeGroupId).HasColumnName("AgeGroupID");

                entity.Property(e => e.Attending).HasColumnType("mediumtext");

                entity.Property(e => e.ContactNumber).HasColumnType("mediumtext");

                entity.Property(e => e.DessertChoiceId).HasColumnName("DessertChoiceID");

                entity.Property(e => e.MainChoiceId).HasColumnName("MainChoiceID");

                entity.Property(e => e.Name).HasColumnType("mediumtext");

                entity.Property(e => e.Notes).HasColumnType("mediumtext");

                entity.Property(e => e.StarterChoiceId).HasColumnName("StarterChoiceID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
