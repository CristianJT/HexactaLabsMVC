﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using HxLabsMVCApplication.Models;

namespace HxLabsMVCApplication.Controllers
{
    public class GenresController : Controller
    {
        public ActionResult Index() {

            var model = new GenreIndexModel();

            var context = new MoviesContext();

            model.Genres = context.Genres.ToList();

            return View(model);
        }
        
    }
}