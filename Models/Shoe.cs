using System;
using System.ComponentModel.DataAnnotations;

namespace MvcShoe.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}