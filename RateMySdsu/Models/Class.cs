using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMySdsu.Models
{
    public class Class
    {
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }
        public string Title { get; set; }
        

        public ICollection<Review> Reviews { get; set; }
    }
}

