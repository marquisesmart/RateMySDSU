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
    public class IndexModel : PageModel
    {
        private readonly RateMySdsu.Data.SDSUContext _context;

        public IndexModel(RateMySdsu.Data.SDSUContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; }

        public async Task OnGetAsync()
        {
            Review = await _context.Reviews
                .Include(r => r.Class)
                .Include(r => r.Student).ToListAsync();
        }
    }
}
