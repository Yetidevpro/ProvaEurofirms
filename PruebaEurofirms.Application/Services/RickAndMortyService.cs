using PruebaEurofirms.Domain.Models;
using PruebaEurofirms.Domain.Repositories;
using PruebaEurofirms.Application.ExternalDTOs;
using PruebaEurofirms.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly ICharacterRepository _repository;

        public RickAndMortyService(HttpClient httpClient, ICharacterRepository repository)
        {
            _httpClient = httpClient;
            _repository = repository;
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            var allCharacters = new List<Character>();
            string url = "https://rickandmortyapi.com/api/character";

            while (url != null)
            {
                var response = await _httpClient.GetFromJsonAsync<RickAndMortyApiResponse>(url);
                foreach (var character in response.Results)
                {
                    var newCharacter = new Character
                    {
                        CharacterId = character.Id,
                        Name = character.Name,
                        Status = character.Status,
                        Gender = character.Gender,
                        Episodes = character.Episode
                    };
                    allCharacters.Add(newCharacter);
                }
                url = response.Info.Next;
            }

            await _repository.SaveCharactersAsync(allCharacters);
            return allCharacters;
        }

        public Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status)
        {
            return _repository.GetCharactersByStatusAsync(status);
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            return _repository.DeleteCharacterAsync(id);
        }
    }
}

  