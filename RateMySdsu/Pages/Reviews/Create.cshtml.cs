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
            // @await Html.PartialAsync("_LoginPartial")
            //int code = User.Identity.GetHashCode();
            //Review.Score = code;

            // Need to get username as string somehow from AccountController

            // 1How to look up Review.StudentID from authenticated user?
            //2 How to relate user's StudentID to Student table?
            //string uname;
            //{
            //    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Public\uname.txt");
            //    uname = file.ReadLine();
            //    file.Close();
            //}
            int studentID = 0;
            studentID = 1;
            // FILEIO
            //int n = _context.Students.Count();
            //{
            //    List<Student> students = _context.Students.ToList();
            //    for (int i = 0; i < students.Count; i++)
            //    {
            //        if (students[i].LastName == uname)
            //        {
            //            studentID = students[i].StudentID;
            //            break;
            //        }
            //    }
            //}
            //if (studentID==0)
            //{
            //    Student stu = new Student();
            //    //stu.StudentID = i+1;
            //    stu.FirstMidName = uname;
            //    stu.LastName = uname;
            //    _context.Students.Add(stu);
            //    _context.SaveChanges();
                
            //    List<Student> students = _context.Students.ToList();
            //    studentID = students[0].StudentID;
            //    for (int i = 0; i < students.Count; i++)
            //    {
            //        if (students[i].LastName == uname)
            //        {
            //            studentID = students[i].StudentID;
            //            break;
            //        }
            //    }
            //}
            //return RedirectToPage("./Index");

            Review.StudentID = studentID;
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}