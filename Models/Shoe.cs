using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcShoe.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}