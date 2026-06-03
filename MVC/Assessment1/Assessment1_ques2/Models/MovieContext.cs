using Assessment1_ques2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assessment1_ques2.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext() : base("MoviesDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}