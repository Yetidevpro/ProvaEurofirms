using PruebaEurofirms.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDTO>> ImportCharactersAsync();
        Task<IEnumerable<CharacterDTO>> GetCharactersByStatusAsync(string status);
        Task<bool> DeleteCharacterAsync(int id);
    }
}

