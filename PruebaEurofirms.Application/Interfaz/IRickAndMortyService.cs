using PruebaEurofirms.Application.DTOs;
using PruebaEurofirms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status);
        Task<bool> DeleteCharacterAsync(int id);
    }
}