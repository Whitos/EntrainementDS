using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntrainementDS.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur, int, string>
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            return await _context.Utilisateurs
                .Include(u => u.Commandes)
                .ToListAsync();
        }

        public async Task<IEnumerable<Utilisateur?>> GetByIdAsync(int id)
        {
            return await _context.Utilisateurs
                .Include(u => u.Commandes)
                .Where(u => u.IdUtilisateur == id)
                .ToListAsync();
        }

        public async Task<Utilisateur?> GetByKeyAsync(string nom)
        {
            return await _context.Utilisateurs
                .Include(u => u.Commandes)
                .FirstOrDefaultAsync(u => u.Nom == nom);
        }

        public async Task AddAsync(Utilisateur entity)
        {
            _context.Utilisateurs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilisateur entityToUpdate, Utilisateur entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Prenom = entity.Prenom;
            entityToUpdate.NumeroRue = entity.NumeroRue;
            entityToUpdate.Rue = entity.Rue;
            entityToUpdate.CodePostal = entity.CodePostal;
            entityToUpdate.Ville = entity.Ville;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Utilisateur entity)
        {
            _context.Utilisateurs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
