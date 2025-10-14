using EntrainementDS.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EntrainementDS.Models.DataManager
{
    public class CommandeManager
    {
        private readonly ApplicationDbContext _context;
        public CommandeManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commande>> GetAllAsync()
        {
            return await _context.Commandes.Include(c => c.Utilisateur).ToListAsync();
        }

        public async Task<IEnumerable<Commande?>> GetByIdAsync(int id)
        {
            return await _context.Commandes
                .Include(c => c.Utilisateur)
                .Where(u => u.IdCommande == id)
                .ToListAsync();
        }

        public async Task<Commande?> GetByKeyAsync(string nom)
        {
            return await _context.Commandes
                .Include(u => u.Utilisateur)
                .FirstOrDefaultAsync(u => u.NomArticle == nom);
        }

        public async Task AddAsync(Commande entity)
        {
            _context.Commandes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commande entityToUpdate, Commande entity)
        {
            entityToUpdate.NomArticle = entity.NomArticle;
            entityToUpdate.IdUtilisateur = entity.IdUtilisateur;
            entityToUpdate.Montant = entity.Montant;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commande entity)
        {
            _context.Commandes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
