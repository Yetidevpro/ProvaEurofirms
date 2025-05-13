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
        Task<bool> SaveCharacterAsync(IEnumerable<Character> character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<Character> GetCharacterByIdAsync(int id);
    }
}
