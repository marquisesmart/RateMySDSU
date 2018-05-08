using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateMySdsu.Models;

namespace RateMySdsu.Data
{
    public class DbInitializer
    {
        public static void Initialize(SDSUContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander"},
                new Student{FirstMidName="Meredith",LastName="Alonso"},
                new Student{FirstMidName="Arturo",LastName="Anand"},
                new Student{FirstMidName="Gytis",LastName="Barzdukas"},
                new Student{FirstMidName="Yan",LastName="Li"},
                new Student{FirstMidName="Peggy",LastName="Justice"},
                new Student{FirstMidName="Laura",LastName="Norman"},
                new Student{FirstMidName="Nino",LastName="Olivetto"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var classes = new Class[]
            {
                new Class{ClassID=1050,Title="Chemistry"},
                new Class{ClassID=4022,Title="Microeconomics"},
                new Class{ClassID=4041,Title="Macroeconomics"},
                new Class{ClassID=1045,Title="Calculus"},
                new Class{ClassID=3141,Title="Trigonometry"},
                new Class{ClassID=2021,Title="Composition"},
                new Class{ClassID=2042,Title="Literature"}
            };
            foreach (Class c in classes)
            {
                context.Classes.Add(c);
            }
            context.SaveChanges();

            var reviews = new Review[]
            {
                new Review{StudentID=1,ClassID=1050,Score=2,Text="word1"},
                new Review{StudentID=1,ClassID=4022,Score=3,Text="word1"},
                new Review{StudentID=1,ClassID=4041,Score=4,Text="word1"},
                new Review{StudentID=2,ClassID=1045,Score=5,Text="word1"},
                new Review{StudentID=2,ClassID=3141,Score=2,Text="word1"},
                new Review{StudentID=2,ClassID=2021,Score=3,Text="word1"},
                new Review{StudentID=3,ClassID=1050,Score=4,Text="word1"},
                new Review{StudentID=4,ClassID=1050,Score=5,Text="word1"},
                new Review{StudentID=4,ClassID=4022,Score=2,Text="word1"},
                new Review{StudentID=5,ClassID=4041,Score=3,Text="word1"},
                new Review{StudentID=6,ClassID=1045,Score=4,Text="word1"},
                new Review{StudentID=7,ClassID=3141,Score=5,Text="word1"},
            };
            foreach (Review e in reviews)
            {
                context.Reviews.Add(e);
            }
            context.SaveChanges();
        }
    }
}
