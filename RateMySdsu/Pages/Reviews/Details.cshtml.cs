using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RateMySdsu.Data;
using RateMySdsu.Models;

namespace RateMySdsu.Pages.Reviews
{
    public class DetailsModel : PageModel
    {
        private readonly RateMySdsu.Data.SDSUContext _context;

        public DetailsModel(RateMySdsu.Data.SDSUContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
