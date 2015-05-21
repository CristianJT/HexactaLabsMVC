using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using HxLabsMVCApplication.App_Start;
using Entities;

namespace HxLabsMVCApplication.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<MoviesContext>(new ContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Movie> Movies { get; set; }



    }
}