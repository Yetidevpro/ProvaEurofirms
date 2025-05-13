using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaEurofirms.Domain.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Gender { get; set; }

        [Required]
        public List<string> Episodes { get; set; } = new List<string>();
    }
}
