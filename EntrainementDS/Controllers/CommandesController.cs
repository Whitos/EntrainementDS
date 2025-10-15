using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrainementDS.Models.EntityFramework;
using EntrainementDS.Models.Repository;
using AutoMapper;
using EntrainementDS.Models.DTO;

namespace EntrainementDS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandesController(IDataRepository<Commande, int, string> _manager, IMapper _commandeMapper) : ControllerBase
    {

        // GET: api/commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetAll()
        {
            var commandes = await _manager.GetAllAsync();
            return new ActionResult<IEnumerable<CommandeDTO>>(_commandeMapper.Map<IEnumerable<CommandeDTO>>(commandes));
        }

        // GET: api/commandes/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<CommandeDTO>> GetById(int id)
        {
            var commande = await _manager.GetByIdAsync(id);
            if (commande is null) return NotFound();

            return _commandeMapper.Map<CommandeDTO>(commande);
        }

        // GET: api/commandes/nomArticle
        [HttpGet("{nomArticle}")]
        [ActionName("GetByNomArticle")]
        public async Task<ActionResult<CommandeDTO>> GetByName(string nomArticle)
        {
            var commande = await _manager.GetByName(nomArticle);
            if (commande is null) return NotFound();

            return _commandeMapper.Map<CommandeDTO>(commande);
        }

        // PUT: api/commandes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommandeDTO dto)
        {
            if (id != dto.IdCommande) return BadRequest();

            var toUpdate = await _manager.GetByIdAsync(id);

            if(toUpdate is null) return NotFound();

            var updated = _commandeMapper.Map<Commande>(dto);
            await _manager.UpdateAsync(toUpdate, updated);

            return NoContent();
        }

        // POST: api/commandes
        [HttpPost]
        public async Task<ActionResult<CommandeDTO>> Post([FromBody] CommandeDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _commandeMapper.Map<Commande>(dto);
            await _manager.AddAsync(entity);
            return CreatedAtAction("GetById", new { id = entity.IdCommande }, entity);
        }

        // DELETE: api/commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _manager.GetByIdAsync(id);

            if(entity is null) return NotFound();

            await _manager.DeleteAsync(entity);
            return NoContent();
        }
    }
}
