using System;
using System.Linq;
using System.Web.Mvc;
using HxLabsMVCApplication.Models;
using Entities;
using System.Data;
using Data;
using Services;
using System.Collections.Generic;


namespace HxLabsMVCApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesService movies = new MoviesService();
        private readonly GenresService genres = new GenresService();

        /*OBTENER TODAS LAS PELÍCULAS ORDENADAS*/
        public ActionResult Index(string SearchString = "")
        {
            var model = new MovieIndexModel();
            if (SearchString == string.Empty)
            {
                model.Movies = movies.GetAll();
            }
            else
            {
                model.Movies = movies.GetAll().Where(m => m.Name.Contains(SearchString));
            }
            

            return View(model);
        }

       

        /*CREAR*/
        public ActionResult Create()
        {
            return View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = new Movie(), Genres = genres.GetAll() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie, ICollection<Guid> selectedGenres)
        {
            if (ModelState.IsValid)
            {
                if (selectedGenres != null)
                {
                    foreach (var selectedGenreId in selectedGenres)
                    {
                        Genre genre = genres.Get(selectedGenreId);

                        if (genre != null)
                            movie.Genres.Add(genre);
                    }
                }

                movies.Create(movie);
                TempData["successmessage"] = "Se ha agregado exitosamente la pelicula: " + movie.Name;
                return RedirectToAction("Index");
            }
            else
                return View("Create", new MovieCreateModel() { ViewAction = ViewAction.Create, Movie = movie, Genres = genres.GetAll() });
        }


        /*EDITAR*/
        public ActionResult Edit(Guid id)
        {
            Movie movie = movies.Get(id);
            return View("Create", new MovieCreateModel() { ViewAction = ViewAction.Edit, Movie = movie, Genres = movie.Genres });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                var m = movies.Update(movie, movie.Id);
                TempData["successmessage"] = "Se ha actualizado exitosamente la pelicula: " + m.Name;
                return RedirectToAction("Index");                            
            }
            else
                return View("Create", new MovieCreateModel() { ViewAction = ViewAction.Edit, Movie = movie });
        }


        /*ELIMINAR*/
        public ActionResult Delete(Guid id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "ERROR al eliminar la película";
            }

            Movie movie = movies.Get(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Movie movieToDelete = movies.Get(id);
                movies.Delete(movieToDelete);
                TempData["successmessage"] = "Se ha eliminado exitosamente la pelicula: " + movieToDelete.Name;
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}