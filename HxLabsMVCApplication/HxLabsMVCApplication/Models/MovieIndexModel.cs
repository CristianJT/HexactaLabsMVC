using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace HxLabsMVCApplication.Models
{
    public class MovieIndexModel
    {
        public MovieIndexModel()
        {
            this.Movies = new List<Movie>();
        }

        public string SearchString { get; set; }
        public ViewAction ViewAction { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}