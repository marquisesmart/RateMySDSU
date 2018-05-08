using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RateMySdsu.Data;
using RateMySdsu.Models;

namespace RateMySdsu.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly RateMySdsu.Data.SDSUContext _context;

        public DetailsModel(RateMySdsu.Data.SDSUContext context)
        {
            _context = context;
        }

        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Classes.SingleOrDefaultAsync(m => m.ClassID == id);

            if (Class == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
