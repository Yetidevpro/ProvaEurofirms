using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEurofirms.Application.DTOs
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public List<string> Episodes { get; set; } = new List<string>();
    }
}
