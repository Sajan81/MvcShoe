using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShoe.Data;
using MvcShoe.Models;

namespace MvcShoe.Controllers
{
    public class ShoesController : Controller
    {
        private readonly MvcShoeContext _context;

        public ShoesController(MvcShoeContext context)
        {
            _context = context;
        }

        // GET: Shoes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Shoe.ToListAsync());
        //}
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var shoes = from m in _context.Shoe
        //                select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        shoes = shoes.Where(s => s.Name.Contains(searchString));
        //    }

        //    return View(await shoes.ToListAsync());
        //}
        // GET: Shoes
        public async Task<IActionResult> Index(string shoeBrand, string searchString)
        {
            // Use LINQ to get list of Brands.
            IQueryable<string> brandQuery = from m in _context.Shoe
                                            orderby m.Brand
                                            select m.Brand;

            var shoes = from m in _context.Shoe
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                shoes = shoes.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(shoeBrand))
            {
                shoes = shoes.Where(x => x.Brand == shoeBrand);
            }

            var shoeBrandVM = new ShoeBrandViewModel
            {
                Brands = new SelectList(await brandQuery.Distinct().ToListAsync()),
                Shoes = await shoes.ToListAsync()
            };

            return View(shoeBrandVM);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;                  // Added The HTTP post method to provide the searchString to the Url
        }
        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,LaunchDate,Name,Type,Price")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,LaunchDate,Name,Type,Price")] Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoe = await _context.Shoe.FindAsync(id);
            _context.Shoe.Remove(shoe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoe.Any(e => e.Id == id);
        }
    }
}
