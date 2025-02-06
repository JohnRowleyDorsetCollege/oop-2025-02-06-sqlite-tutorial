using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain
{
    public  class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public int Year { get; set; }

        public string Genre { get; set; }   
    }
}
