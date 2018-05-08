using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMySdsu.Data;
using RateMySdsu.Models;

namespace RateMySdsu.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly RateMySdsu.Data.SDSUContext _context;

        public EditModel(RateMySdsu.Data.SDSUContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews
                .Include(r => r.Class)
                .Include(r => r.Student).SingleOrDefaultAsync(m => m.ReviewID == id);

            if (Review == null)
            {
                return NotFound();
            }
           ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "ClassID");
           ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ReviewID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
