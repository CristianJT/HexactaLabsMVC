using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HxLabsMVCApplication.Models;
using Entities;


namespace HxLabsMVCApplication.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var model = new MovieIndexModel();

            var context = new MoviesContext();

            model.Movies = context.Movies.OrderBy(x => x.Name).ToList();
            //Devuelve la lista ordenada alfabeticamente
         
            return View(model);
        }

        //PUNTO 2 (NO FUNCIONA)
        //public ActionResult Create()
        //{
        //    return this.View(new MoviesCreateModel() { ViewAction = ViewAction.Create, Movie = new Movie()});
        //}

    }
}