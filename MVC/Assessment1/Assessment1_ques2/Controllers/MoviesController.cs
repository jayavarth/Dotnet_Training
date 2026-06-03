using Assessment1_ques2.Models;
using Assessment1_ques2.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Assessment1_ques2.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            var data = repo.GetAll();
            return View(data ?? new List<Movie>());   

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            repo.Insert(m);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            repo.Update(m);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int Mid)   
        {
            repo.Delete(Mid);
            repo.Save();

            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var data = repo.GetByYear(year);
            return View(data ?? new List<Movie>());
        }

        public ActionResult MoviesByDirector(string director)
        {
            var data = repo.GetByDirector(director);
            return View(data ?? new List<Movie>());
        }
    }
}