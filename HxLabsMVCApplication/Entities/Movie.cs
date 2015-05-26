using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Movie
    {

        public Movie()
        {
            this.Genres = new HashSet<Genre>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }


        public string Plot { get; set; }

        public string CoverLink { get; set; }

        [Required]
        [Range(30, 300)]
        public int? Runtime { get; set; }

        public ICollection<Genre> Genres { get; set; }
        

    }
}