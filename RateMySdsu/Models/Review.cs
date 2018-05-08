using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateMySdsu.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }


        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
