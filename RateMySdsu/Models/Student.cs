using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateMySdsu.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        //public DateTime EnrollmentDate { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
