using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HxLabsMVCApplication.Models;
using Entities;
using System.Data;
using System.Data.Entity;


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
            return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = new Movie(), Genres });
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
                    this.TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;
                    return RedirectToAction("Index");
                    
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = movie });
        }

        /*EDITAR*/

        public ActionResult Edit(Guid id)
        {
            var movie = context.Movies.Find(id);

            return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Edit, Movie = movie });
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                var movieDb = context.Movies.Find(movie.Id);

                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.Runtime = movie.Runtime;
                movieDb.CoverLink = movie.CoverLink;
                movieDb.Plot = movie.Plot;

                //context.Entry(movieDb).State = EntityState.Modified;
                context.SaveChanges();

                this.TempData["successmessage"] = "Se ha actualizado exitosamente la pelicula: " + movie.Name;

                return this.RedirectToAction("Index");
            }
            else
            {
                return this.View("Create", new MovieCreateModel() { ViewAction = ViewAction.Edit, Movie = movie });
            }

        }
    }
}