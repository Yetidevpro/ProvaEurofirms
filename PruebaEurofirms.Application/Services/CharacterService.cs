using PruebaEurofirms.Application.DTOs;
using PruebaEurofirms.Application.ExternalDTOs;
using PruebaEurofirms.Application.Interfaces;
using PruebaEurofirms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRickAndMortyService _rickAndMortyService;

        public CharacterService(IRickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        public async Task<IEnumerable<CharacterDTO>> ImportCharactersAsync()
        {
            var characters = await _rickAndMortyService.GetAllCharactersAsync();
            var dtoList = new List<CharacterDTO>();

            foreach (var c in characters)
            {
                dtoList.Add(new CharacterDTO
                {
                    CharacterId = c.CharacterId,
                    Name = c.Name,
                    Status = c.Status,
                    Gender = c.Gender,
                    Episodes = c.Episodes
                });
            }

            return dtoList;
        }

        public async Task<IEnumerable<CharacterDTO>> GetCharactersByStatusAsync(string status)
        {
            var characters = await _rickAndMortyService.GetCharactersByStatusAsync(status);
            var dtoList = new List<CharacterDTO>();

            foreach (var c in characters)
            {
                dtoList.Add(new CharacterDTO
                {
                    CharacterId = c.CharacterId,
                    Name = c.Name,
                    Status = c.Status,
                    Gender = c.Gender,
                    Episodes = c.Episodes
                });
            }

            return dtoList;
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            return _rickAndMortyService.DeleteCharacterAsync(id);
        }
    }
}


