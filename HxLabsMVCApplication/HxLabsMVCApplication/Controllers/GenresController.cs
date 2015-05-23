using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using HxLabsMVCApplication.Models;
using Data;
using Services;
using System.Data;

namespace HxLabsMVCApplication.Controllers
{
    public class GenresController : Controller
    {
        private GenresService genres = new GenresService();

        /*OBTENER TODAS LAS PELÍCULAS ORDENADAS*/
        public ActionResult Index()
        {
            var model = new GenreIndexModel();
            model.Genres = genres.GetAll();
            return View(model);
        }

        ///*OBTENER LISTA DE GENEROS FILTRADA*/
        //public ActionResult Index()
        //{
        //    var model = new GenreIndexModel();
        //    model.Genres = genres.Select();
        //    return View(model);
        //}

        /*CREAR*/
        public ActionResult Create()
        {
            return View("Create", new GenreCreateModel() { ViewAction = ViewAction.Create, Genre = new Genre() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genres.Create(genre);
                TempData["successmessage"] = "Se ha agregado exitosamente el genero: " + genre.Name;
                return RedirectToAction("Index");
            }
            else
                return View("Create", new GenreCreateModel() { ViewAction = ViewAction.Create, Genre = genre });
        }

        /*EDITAR*/
        public ActionResult Edit(int id)
        {
            Genre genre = genres.Get(id);
            return View("Create", new GenreCreateModel() { ViewAction = ViewAction.Edit, Genre = genre });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (this.ModelState.IsValid)
            {
                var g = genres.Update(genre, genre.Id);
                TempData["successmessage"] = "Se ha actualizado exitosamente el genero: " + g.Name;
                return RedirectToAction("Index");
            }
            else
                return View("Create", new GenreCreateModel() { ViewAction = ViewAction.Edit, Genre = genre });
        }


        /*ELIMINAR*/
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "ERROR al eliminar el género";
            }

            Genre genre= genres.Get(id);
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Genre genreToDelete = genres.Get(id);
                genres.Delete(genreToDelete);
                TempData["successmessage"] = "Se ha eliminado exitosamente la pelicula: " + genreToDelete.Name;
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
