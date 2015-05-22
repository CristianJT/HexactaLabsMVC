using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using System.Linq.Expressions;

namespace Services
{
    public class MoviesService
    {
        private MoviesContext context = new MoviesContext();

        /*OBTENER TODAS LAS PELÍCULAS*/
        public IList<Movie> GetAll()
        {
            return context.Movies.OrderBy(x => x.Name).ToList();
        }

        /*OBTENER UNA PELÍCULA*/
        public Movie Get (Guid id)
        {
            return context.Movies.Find(id);
        }

        /*CREAR UNA PELÍCULA*/
        public Movie Create(Movie m)
        {
            context.Movies.Add(m);
            context.SaveChanges();
            return m;
        }

        /*EDITAR UNA PELÍCULA*/
        public Movie Update(Movie m, Guid id)
        {
            Movie movieCurrent = context.Movies.Find(id);
            if (movieCurrent != null)
            {
                context.Entry(movieCurrent).CurrentValues.SetValues(m);
                context.SaveChanges();
            }
            return movieCurrent;
        }

        /*ELIMINAR UNA PELÍCULA*/
        public void Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
