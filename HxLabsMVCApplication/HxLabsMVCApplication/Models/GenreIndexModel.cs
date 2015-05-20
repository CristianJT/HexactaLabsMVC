using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace HxLabsMVCApplication.Models
{
    public class GenreIndexModel
    {
        public GenreIndexModel()
        {
            this.Genres = new List<Genre>();
        }

        public ViewAction ViewAction { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}