using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using HxLabsMVCApplication.Models;
 

namespace ServicesLayer
{
    public class MoviesService
    {
        private MoviesContext context = new MoviesContext();

        public IList<Movie> getAllMovies()
        {
           return (context.Movies.OrderBy(x => x.Name).ToList());
        }
    }
}
