using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuebaEurofirms.Infrastructure.ExternalDTOs
{
    public class RickAndMortyApiResponse
    {
        public ApiInfo Info { get; set; }
        public List<CharacterResponse> Results { get; set; }
    }

}
