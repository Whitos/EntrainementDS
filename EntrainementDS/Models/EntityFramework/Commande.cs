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
        [Column("COM_MONTANT")] 
        public int Montant { get; set; }

        [Required]
        [ForeignKey(nameof(Utilisateur.IdUtilisateur))]
        [InverseProperty(nameof(Utilisateur.Commandes))]
        public virtual Utilisateur Utilisateur { get; set; } = null!;

    }
}
