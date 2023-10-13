using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcShoe.Models
{
    public class Shoe
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Brand { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        public string Name { get; set; }


        [StringLength(40, MinimumLength = 4)]
        [Required]
        public string Type { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }          // Added new field here
    }
}