using Microsoft.AspNetCore.Mvc;
using PruebaEurofirms.Application.DTOs;
using PruebaEurofirms.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace PruebaEurofirms.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public RickAndMortyController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // Endpoint 1: Importar personajes
        [HttpPost("import")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> ImportCharacters()
        {
            var result = await _characterService.ImportCharactersAsync();
            return Ok(result);
        }

        // Endpoint 2: Mostrar personajes por estat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetByStatus([FromQuery] string status)
        {
            var result = await _characterService.GetCharactersByStatusAsync(status);
            return Ok(result);
        }

        // Endpoint 3: Eliminar personaje per ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _characterService.DeleteCharacterAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

