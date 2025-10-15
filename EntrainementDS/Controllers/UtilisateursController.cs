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
    /// <summary>
    /// Contrôleur REST permettant de gérer les marques.
    /// Les méthodes exposent ou consomment des DTO afin
    /// d’assurer la séparation entre le modèle de domaine
    /// et la couche API.
    /// </summary>
    /// <param name="_manager"></param>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilisateursController(IDataRepository<Utilisateur, int, string> _manager, IMapper _utilisateurMapper) : ControllerBase
    {
        /// <summary>
        /// Récupère la liste de toutes les marques.
        /// </summary>
        /// <returns>
        /// /// Une liste de <see cref="MarqueDTO"/> (200 OK).
        /// </returns>
        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilisateurDTO>>> GetAll()
        {
            var utilisateurs = await _manager.GetAllAsync();
            return new ActionResult<IEnumerable<UtilisateurDTO>>(_utilisateurMapper.Map<IEnumerable<UtilisateurDTO>>(utilisateurs));
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<UtilisateurDTO>> GetById(int id)
        {
            var utilisateur = await _manager.GetByIdAsync(id);
            if (utilisateur is null) return NotFound();

            return _utilisateurMapper.Map<UtilisateurDTO>(utilisateur);
        }

        [HttpGet("{str}")]
        public async Task<ActionResult<UtilisateurDTO>> GetByName(string str)
        {
            var utilisateur = await _manager.GetByName(str);
            if (utilisateur is null) return NotFound();

            return _utilisateurMapper.Map<UtilisateurDTO>(utilisateur);
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UtilisateurDTO dto)
        {
            if(id != dto.IdUtilisateur)
                return BadRequest();

            var toUpdate = await _manager.GetByIdAsync(id);

            if (toUpdate == null)
                return NotFound();

            var updatedEntity = _utilisateurMapper.Map<Utilisateur>(dto);
            await _manager.UpdateAsync(toUpdate, updatedEntity);

            return NoContent();
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> Post([FromBody] UtilisateurDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _utilisateurMapper.Map<Utilisateur>(dto);
            await _manager.AddAsync(entity);

            return CreatedAtAction("GetById", new { id = entity.IdUtilisateur }, entity);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _manager.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _manager.DeleteAsync(entity);
            return NoContent();
        }
    }
}
