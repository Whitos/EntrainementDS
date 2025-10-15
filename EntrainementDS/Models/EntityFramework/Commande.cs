using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntrainementDS.Models.EntityFramework
{
    [Table("T_E_COMMANDE_COM")]
    public class Commande
    {
        [Key]
        [Column("COM_ID")]
        public int IdCommande { get; set; }

        [Required]  
        [Column("COM_NOMARTICLE")]
        public string NomArticle { get; set;}

        [Required]
        [Column("UTI_ID")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("COM_MONTANT", TypeName = "decimal(10,2)")]
        public decimal MontantInitial { get; set; }

        [Required]
        [Column("COM_NOMBREECHEANCES")]
        [Range(1, 4, ErrorMessage = "Le nombre d'échéances doit être entre 1 et 4")]
        public int NombreEcheances { get; set; } = 1;

        [Required]
        [Column("COM_MONTANT", TypeName = "decimal(10,2)")]
        public decimal MontantTotal { get; set; }

        [Required]
        [Column("COM_MONTANT", TypeName = "decimal(10,2)")]
        public decimal Majoration { get; set; }

        [Required]
        [ForeignKey(nameof(Utilisateur.IdUtilisateur))]
        [InverseProperty(nameof(Utilisateur.Commandes))]
        public virtual Utilisateur Utilisateur { get; set; } = null!;


        // Méthode pour calculer le montant total avec majoration
        public void CalculerMontantTotal()
        {
            if (NombreEcheances > 1)
            {
                Majoration = MontantInitial * 0.10m;
                MontantTotal = MontantInitial + Majoration;
            }
            else
            {
                Majoration = 0;
                MontantTotal = MontantInitial;
            }
        }

        // Méthode pour obtenir le montant par échéance
        public decimal GetMontantParEcheance()
        {
            return MontantTotal / NombreEcheances;
        }
    }
}
