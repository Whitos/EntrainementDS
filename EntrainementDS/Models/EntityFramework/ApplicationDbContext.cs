using Microsoft.EntityFrameworkCore;

namespace EntrainementDS.Models.EntityFramework
{
    public partial class ApplicationDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=EntrainementDS;Username=postgres;Password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(user => user.IdUtilisateur).HasName("PK_UTI");

                entity.HasMany(user => user.Commandes)
                    .WithOne(commande => commande.Utilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(commande => commande.IdCommande).HasName("PK_COM");

                // Relation: 1 (Utilisateur) -> N (Commandes)
                entity.HasOne(commande => commande.Utilisateur) // chaque commande est liée a 1 seul utilisateur
                    .WithMany(user => user.Commandes) // chaque utilisateur peut avoir plusieurs commandes
                    .HasForeignKey(commande => commande.IdUtilisateur) // clé étrangère dans Commande
                    .OnDelete(DeleteBehavior.ClientSetNull) // comportement à la suppression
                    .HasConstraintName("FK_COM_UTI");
            });

        }
    }
}
