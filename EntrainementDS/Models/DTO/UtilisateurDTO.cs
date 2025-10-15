namespace EntrainementDS.Models.DTO
{
    public class UtilisateurDTO
    {
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Ville { get; set; } = "Annecy";
        public int? NbCommande { get; set; }
    }
}
