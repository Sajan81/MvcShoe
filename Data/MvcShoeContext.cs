using Microsoft.EntityFrameworkCore;
using MvcShoe.Models;

namespace MvcShoe.Data
{
    public class MvcShoeContext : DbContext
    {
        public MvcShoeContext(DbContextOptions<MvcShoeContext> options)
            : base(options)
        {
        }

        public DbSet<Shoe> Shoe { get; set; }
    }
}