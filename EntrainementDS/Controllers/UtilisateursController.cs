using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.Repository;

namespace EntrainementDS.Controllers
{
    [Route("api/utilisateurs")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IDataRepository<Utilisateur, int, string> _repository;

        public UtilisateursController(IDataRepository<Utilisateur, int, string> repository)
        {
            this._repository = repository;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            var utilisateurs = await _repository.GetAllAsync();
            return Ok(utilisateurs);
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _repository.GetByIdAsync(id);
            if (utilisateur == null) return NotFound();
            return Ok(utilisateur);
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            var existingUtilisateurs = await _repository.GetByIdAsync(id);
            var utilisateurToUpdate = existingUtilisateurs.FirstOrDefault();

            if (utilisateurToUpdate == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(utilisateurToUpdate, utilisateur);
            return NoContent();
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            await _repository.AddAsync(utilisateur);
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.IdUtilisateur }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateurs = await _repository.GetByIdAsync(id);
            var utilisateur = utilisateurs.FirstOrDefault();

            if (utilisateur == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(utilisateur);
            return NoContent();
        }
    }
}
