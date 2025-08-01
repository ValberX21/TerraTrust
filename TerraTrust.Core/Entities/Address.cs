using System.ComponentModel.DataAnnotations;

namespace TerraTrust.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
