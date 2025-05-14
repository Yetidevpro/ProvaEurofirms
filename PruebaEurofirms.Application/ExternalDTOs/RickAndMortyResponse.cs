using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.ExternalDTOs
{
    public class RickAndMortyApiResponse
    {
        public ApiInfo Info { get; set; }
        public List<ExternalCharacter> Results { get; set; }
    }

}
