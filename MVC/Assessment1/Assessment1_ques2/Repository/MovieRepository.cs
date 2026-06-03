using Assessment1_ques2.Models;
using Assessment1_ques2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessment1_ques2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MovieContext db = new MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Movie m = db.Movies.Find(id);

            if (m != null)   
            {
                db.Movies.Remove(m);
            }
        }



        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies
                     .Where(m => m.DateofRelease.Year == year)
                     .ToList();
        }

        public IEnumerable<Movie> GetByDirector(string director)
        {
            return db.Movies
                     .Where(m => m.DirectorName == director)
                     .ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
