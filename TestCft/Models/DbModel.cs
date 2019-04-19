using Microsoft.EntityFrameworkCore;

namespace TestCft.Models
{
    public partial class DbModel : DbContext
    {
        public virtual DbSet<App> Apps { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        public DbModel(DbContextOptions<DbModel> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Apps__737584F60BC1B58F")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Finished).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__AppId__4D94879B");
            });
        }
    }
}
