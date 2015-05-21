using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace HxLabsMVCApplication.Models
{
    public class MovieCreateModel
    {
        public ViewAction ViewAction { get; set; }

        public Movie Movie { get; set; }
    }
}