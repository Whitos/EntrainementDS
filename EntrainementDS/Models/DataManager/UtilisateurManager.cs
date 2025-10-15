using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntrainementDS.Models.DataManager
{
    public class UtilisateurManager(ApplicationDbContext context) : IDataRepository<Utilisateur, int, string>
    {
        public async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            return await context.Utilisateurs
                .Include(u => u.Commandes)
                .ToListAsync();
        }

        public async Task<Utilisateur?> GetByIdAsync(int id)
        {
            return await context.Utilisateurs
                .Include(u => u.Commandes)
                .FirstOrDefaultAsync(u => u.IdUtilisateur == id);
        }

        public async Task<Utilisateur?> GetByName(string str)
        {
            return await context.Utilisateurs
                .Include(u => u.Commandes).
                FirstOrDefaultAsync(u => u.Nom.ToLower().Contains(str.ToLower()));
        }

        public async Task<Utilisateur?> GetByKeyAsync(string nom)
        {
            return await context.Utilisateurs
                .Include(u => u.Commandes)
                .FirstOrDefaultAsync(u => u.Nom == nom);
        }

        public async Task AddAsync(Utilisateur entity)
        {
            await context.Utilisateurs.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilisateur entityToUpdate, Utilisateur entity)
        {
            context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Utilisateur entity)
        {
            context.Utilisateurs.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
