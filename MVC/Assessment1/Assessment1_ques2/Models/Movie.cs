using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assessment1_ques2.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        public string Moviename { get; set; }

        public string DirectorName { get; set; }

        public DateTime DateofRelease { get; set; }
    }
}
