using PruebaEurofirms.Application.DTOs;
using PruebaEurofirms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.Interfaz
{
    public interface IRickAndMortyService
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
    }
}
