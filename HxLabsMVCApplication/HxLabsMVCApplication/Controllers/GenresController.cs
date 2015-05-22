using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using HxLabsMVCApplication.Models;
using Data;

namespace HxLabsMVCApplication.Controllers
{
    public class GenresController : Controller
    {
        public ActionResult Index() {

            var model = new GenreIndexModel();

            var context = new MoviesContext();

            model.Genres = context.Genres.OrderBy(g => g.Name).ToList();

            return View(model);
        }
        
    }
}
