using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaEurofirms.Domain.Models;

namespace PruebaEurofirms.Domain.Repositories
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status);
        Task<bool> SaveCharactersAsync(IEnumerable<Character> characters);
        Task<bool> DeleteCharacterAsync(int id);
        Task<Character> GetCharacterByIdAsync(int id);
    }
}
