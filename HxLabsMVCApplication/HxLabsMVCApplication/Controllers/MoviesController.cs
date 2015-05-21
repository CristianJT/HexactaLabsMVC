using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HxLabsMVCApplication.Models;
using Entities;
using System.Data;


namespace HxLabsMVCApplication.Controllers
{
    public class MoviesController : Controller
    {
        /*Declaro una variable de tipo MoviesContext*/
        private MoviesContext context = new MoviesContext();

        public ActionResult Index()
        {
            var model = new MovieIndexModel();

            model.Movies = context.Movies.OrderBy(x => x.Name).ToList();
         
            return View(model);
        }

        /*CREAR*/
        public ActionResult Create()
        {
            return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = new Movie() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, ReleaseDate, Plot, CoverLink, RunTime")]Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = movie });
        }

    }
}