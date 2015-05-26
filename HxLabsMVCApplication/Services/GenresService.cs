using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenresService
    {
        private MoviesContext context = new MoviesContext();

        /*OBTENER TODAS LOS GENEROS*/
        public IList<Genre> GetAll()
        {
            return context.Genres.OrderBy(x => x.Name).ToList();
        }

        /*OBTENER UN GENERO*/
        public Genre Get(Guid id)
        {
            return context.Genres.Find(id);
        }

        /*CREAR UN GENERO*/
        public Genre Create(Genre g)
        {
            context.Genres.Add(g);
            context.SaveChanges();
            return g;
        }

        /*EDITAR UN GENERO*/
        public Genre Update(Genre g, Guid id)
        {
            Genre genreCurrent = context.Genres.Find(id);
            if (genreCurrent != null)
            {
                context.Entry(genreCurrent).CurrentValues.SetValues(g);
                context.SaveChanges();
            }
            return genreCurrent;
        }

        /*ELIMINAR UN GENERO*/
        public void Delete(Genre genre)
        {
            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}
