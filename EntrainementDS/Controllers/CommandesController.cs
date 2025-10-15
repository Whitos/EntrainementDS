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
    [Route("api/commandes")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly IDataRepository<Commande, int, string> _repository;


        public CommandesController(IDataRepository<Commande, int, string> repository)
        {
            this._repository = repository;
        }

        // GET: api/commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            var commandes = await _repository.GetAllAsync();
            return Ok(commandes);
        }

        // GET: api/commandes/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _repository.GetByIdAsync(id);
            if (commande == null) return NotFound();

            return Ok(commande);
        }

        // GET: api/commandes/nomArticle
        [HttpGet("{nomArticle}")]
        [ActionName("GetByNomArticle")]
        public async Task<ActionResult<Commande>> GetCommandeByNomArticle(string nomArticle)
        {
            var commande = await _repository.GetByKeyAsync(nomArticle);
            if (commande == null) return NotFound();
            return Ok(commande);
        }

        // PUT: api/commandes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            var existingCommandes = await _repository.GetByIdAsync(id);
            var commandeToUpdate = existingCommandes.FirstOrDefault();

            if (commandeToUpdate == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(commandeToUpdate, commande);
            return NoContent();
        }

        // POST: api/commandes
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            await _repository.AddAsync(commande);
            return CreatedAtAction(nameof(GetCommande), new { id = commande.IdCommande }, commande);
        }

        // DELETE: api/commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commandes = await _repository.GetByIdAsync(id);
            var commande = commandes.FirstOrDefault();

            if (commande == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(commande);
            return NoContent();
        }
    }
}
