namespace EntrainementDS.Models.DTO
{
    public class CommandeDTO
    {
        public int IdCommande { get; set; }
        public string NomArticle { get; set; }
        public int IdUtilisateur { get; set; }
        public decimal MontantInitial { get; set; }
        public int NombreEcheances { get; set; } = 1;
        public decimal MontantTotal { get; set; }
        public decimal Majoration { get; set; }
    }
}
