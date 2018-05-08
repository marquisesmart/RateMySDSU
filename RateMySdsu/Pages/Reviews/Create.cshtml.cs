using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RateMySdsu.Data;
using RateMySdsu.Models;

namespace RateMySdsu.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly RateMySdsu.Data.SDSUContext _context;

        public CreateModel(RateMySdsu.Data.SDSUContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Title");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "FirstMidName");
            ViewData["Title"] = new SelectList(_context.Classes, "Title", "Title");
            //_context.
            //if()
            //return RedirectToPage("/Account/Login");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //int code = User.Identity.GetHashCode();
            //Review.Score = code;
            // 1How to look up Review.StudentID from authenticated user?
            //2 How to relate user's StudentID to Student table?
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}