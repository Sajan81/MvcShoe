using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcShoe.Models
{
    public class ShoeBrandViewModel
    {
        public List<Shoe> Shoes { get; set; }
        public SelectList Brands { get; set; }
        public string ShoeBrand { get; set; }
        public string SearchString { get; set; }
    }
}