using Entities;
using HxLabsMVCApplication.App_Start;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<MoviesContext>(new ContextInitializer());
        }

        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Movie>()
                .HasMany<Genre>(m => m.Genres)
                .WithMany(g => g.Movies)
                .Map(mg =>
                        {
                            mg.MapLeftKey("MovieId");
                            mg.MapRightKey("GenreId");
                            mg.ToTable("MovieGenre");
                        });

            
        }

       
    }
}
