using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Movie
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Plot { get; set; }

        public string CoverLink { get; set; }

        public int? Runtime { get; set; }
        

    }
}