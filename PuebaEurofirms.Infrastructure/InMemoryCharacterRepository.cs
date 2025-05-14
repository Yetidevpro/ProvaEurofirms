using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaEurofirms.Domain.Models;
using PruebaEurofirms.Domain.Repositories;

namespace PruebaEurofirms.Infrastructure.Repositories
{
    public class InMemoryCharacterRepository : ICharacterRepository
    {
        private readonly List<Character> _characters = new();

        public async Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status)
        {
            var result = _characters.Where(c =>
                c.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(result);
        }

        public async Task<bool> SaveCharactersAsync(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                if (!_characters.Any(c => c.CharacterId == character.CharacterId))
                {
                    _characters.Add(character);
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            if (character != null)
            {
                _characters.Remove(character);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            return await Task.FromResult(character);
        }
    }
}
