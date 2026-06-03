using Assessment1_ques2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessment1_ques2.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string director);
        void Save();
    }
}