using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntrainementDS.Models.DataManager
{
    public class CommandeManager(ApplicationDbContext context) : IDataRepository<Commande, int, string>
    {
        public async Task<IEnumerable<Commande>> GetAllAsync()
        {
            return await context.Commandes
                .Include(c => c.Utilisateur)    // Charge la relation avec Utilisateur
                .ToListAsync();
        }

        public async Task<Commande?> GetByIdAsync(int id)
        {
            return await context.Commandes
                .Include(c => c.Utilisateur)
                .FirstOrDefaultAsync(c => c.IdCommande == id);
        }

        public async Task<Commande?> GetByKeyAsync(string nom)
        {
            return await context.Commandes
                .Include(u => u.Utilisateur)
                .FirstOrDefaultAsync(u => u.NomArticle == nom);
        }

        public async Task<Commande?> GetByName(string str)
        {
            return await context.Commandes
                .Include(c => c.Utilisateur)
                .FirstOrDefaultAsync(c => c.NomArticle.ToLower().Contains(str.ToLower()));
        }

        public async Task AddAsync(Commande entity)
        {
            await context.Commandes.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commande entityToUpdate, Commande entity)
        {
            context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commande entity)
        {
            context.Commandes.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
