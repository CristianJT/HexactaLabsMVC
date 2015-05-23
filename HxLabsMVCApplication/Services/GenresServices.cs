using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenresServices
    {
        private MoviesContext context = new MoviesContext();

        /*OBTENER TODAS LOS GENEROS ORDENADOS ALFABETICAMENTE*/
        public IList<Genres> GetAll()
        {
            return context.Genres.OrderBy(x => x.Name).ToList();
        }
    }
}
