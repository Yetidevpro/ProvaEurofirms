using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaEurofirms.Domain.Models;
using PruebaEurofirms.Domain.Repositories;

namespace PuebaEurofirms.Infrastructure
{
    public class InMemoryCharacterRepository : ICharacterRepository
    {
        private readonly List<Character> _characters = new();

        // Metode per obtenir els personatges pel seu estat
        public Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status)
        {
            var result = _characters.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(result);
        }

        // Métode per guardar un personatge
        public Task<bool> SaveCharacterAsync(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                //comprovació per evitar duplicats
                if (!_characters.Any(c => c.CharacterId == character.CharacterId))
                {
                    _characters.Add(character);
                }
            }
            return Task.FromResult(true);
        }

        // Métode para eliminar un personaje mitjançant la seva id
        public Task<bool> DeleteCharacterAsync(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            if (character != null)
            {
                _characters.Remove(character);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        // Métode per obtenir un personaje per la seva id
        public Task<Character> GetCharacterByIdAsync(int id)
        {
            var character = _characters.FirstOrDefault(c => c.CharacterId == id);
            return Task.FromResult(character);
        }
    }
}
