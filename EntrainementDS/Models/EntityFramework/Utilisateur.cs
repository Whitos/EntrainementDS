using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntrainementDS.Models.EntityFramework
{
    [Table("T_E_UTILISATEUR_UTI")]
    public class Utilisateur
    {
        [Key]
        [Column("UTI_ID")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("UTI_NOM")]
        public string Nom { get; set; } = null!;

        [Required]
        [Column("UTI_PRENOM")]
        public string Prenom { get; set; } = null!;

        [Required]
        [Column("UTI_NUMERORUE")]
        [MaxLength(10)]
        public int NumeroRue { get; set; }

        [Required]
        [Column("UTI_RUE")]
        public string Rue { get; set; } = null!;

        [Required]
        [Column("UTI_CODEPOSTAL")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres.")]
        public string CodePostal { get; set; }

        [Required]
        [Column("UTI_VILLE")]
        public string Ville { get; set; } = "Annecy";

        [Required]
        [InverseProperty(nameof(Commande.Utilisateur))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    }
}
