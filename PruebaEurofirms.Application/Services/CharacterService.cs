using PruebaEurofirms.Application.DTOs;
using PruebaEurofirms.Application.Interfaz;
using PruebaEurofirms.Domain.Models;
using PruebaEurofirms.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        private readonly IRickAndMortyService _rickAndMortyService;

        public CharacterService(ICharacterRepository repository, IRickAndMortyService rickAndMortyService)
        {
            _repository = repository;
            _rickAndMortyService = rickAndMortyService;
        }

        public async Task<IEnumerable<CharacterDTO>> ImportCharactersAsync()
        {
            var characters = await _rickAndMortyService.ImportAllCharactersAsync();

            return characters.Select(c => new CharacterDTO
            {
                CharacterId = c.CharacterId,
                Name = c.Name,
                Status = c.Status,
                Gender = c.Gender,
                Episodes = c.Episodes
            });
        }

        public async Task<IEnumerable<CharacterDTO>> GetCharactersByStatusAsync(string status)
        {
            var characters = await _repository.GetCharactersByStatusAsync(status);

            return characters.Select(c => new CharacterDTO
            {
                CharacterId = c.CharacterId,
                Name = c.Name,
                Status = c.Status,
                Gender = c.Gender,
                Episodes = c.Episodes
            });
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            return _repository.DeleteCharacterAsync(id);
        }
    }

}
