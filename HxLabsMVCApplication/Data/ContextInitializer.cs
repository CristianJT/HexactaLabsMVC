using System;
using System.Collections.Generic;
using System.Data.Entity;
using Entities;
using Data;

namespace HxLabsMVCApplication.App_Start
{
    public class ContextInitializer : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            var genres = new List<Genre>() {
                new Genre() { Name="Accion", Id = Guid.NewGuid() },
                new Genre() { Name="Ficcion", Id = Guid.NewGuid() },
                new Genre() { Name="Aventura", Id = Guid.NewGuid() },
                new Genre() { Name="Terror", Id = Guid.NewGuid() },
                new Genre() { Name="Drama", Id = Guid.NewGuid() }
            };

            var movies = new List<Movie>() 
            {
                new Movie() { Name="Minions", Id = Guid.NewGuid(), Plot="Minions Stuart, Kevin and Bob are recruited by Scarlet Overkill, a super-villain who, alongside her inventor husband Herb, hatches a plot to take over the world.",ReleaseDate= DateTime.Now,Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTUwNjcxNzAwOF5BMl5BanBnXkFtZTgwNzEzMzIzNDE@._V1_SX214_AL_.jpg" },
                new Movie() { Name="Edge of tomorrow", Id = Guid.NewGuid(), Plot="A military officer is brought into an alien war against an extraterrestrial enemy who can reset the day and know the future. When this officer is enabled with the same power, he teams up with a Special Forces warrior to try and end the war.",ReleaseDate= DateTime.Now,Runtime = 120, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTc5OTk4MTM3M15BMl5BanBnXkFtZTgwODcxNjg3MDE@._V1_SX214_AL_.jpg" },
                new Movie() { Name="Transcendence", Id = Guid.NewGuid(), Plot="A scientist's drive for artificial intelligence, takes on dangerous implications when his consciousness is uploaded into one such program.",ReleaseDate= DateTime.Now,Runtime = 120, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTc1MjQ3ODAyOV5BMl5BanBnXkFtZTgwNjI1NDQ0MTE@._V1_SX214_AL_.jpg" },
                new Movie() { Name="Interstellar", Id = Guid.NewGuid(), Plot="A team of explorers travel through a wormhole in an attempt to ensure humanity's survival.",ReleaseDate= DateTime.Now,Runtime = 120, CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_SX214_AL_.jpg"},
                new Movie() { Name="I Robot", Id = Guid.NewGuid(), Plot="In 2035 a technophobic cop investigates a crime that may have been perpetrated by a robot, which leads to a larger threat to humanity.",ReleaseDate= DateTime.Now,Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTQwNzI5NTQ0OF5BMl5BanBnXkFtZTYwMTI3Mjk2._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Avatar", Id = Guid.NewGuid(), Plot = "A Paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SY317_CR0,0,214,317_AL_.jpg" },
                new Movie() { Name = "After earth", Id = Guid.NewGuid(), Plot = "A crash landing leaves Kitai Raige and his father Cypher stranded on Earth, a millennium after events forced humanity's escape. With Cypher injured, Kitai must embark on a perilous journey to signal for help." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTY3MzQyMjkwMl5BMl5BanBnXkFtZTcwMDk2OTE0OQ@@._V1_SX214_AL_.jpg"},
                new Movie() { Name = "Back to the future", Id = Guid.NewGuid(), Plot = "A young man is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his friend, Dr. Emmett Brown, and must make sure his high-school-age parents unite in order to save his own existence." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMjA5NTYzMDMyM15BMl5BanBnXkFtZTgwNjU3NDU2MTE@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Star Trek Into Darkness", Id = Guid.NewGuid(), Plot = "After the crew of the Enterprise find an unstoppable force of terror from within their own organization, Captain Kirk leads a manhunt to a war-zone world to capture a one-man weapon of mass destruction." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTk2NzczOTgxNF5BMl5BanBnXkFtZTcwODQ5ODczOQ@@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Guardians of the Galaxy", Id = Guid.NewGuid(), Plot = "A group of intergalactic criminals are forced to work together to stop a fanatical warrior from taking control of the universe." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMTAwMjU5OTgxNjZeQTJeQWpwZ15BbWU4MDUxNDYxODEx._V1_SX214_AL_.jpg" },
                new Movie() { Name = "The Lord of the Rings: The Return of the King", Id = Guid.NewGuid(), Plot = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMjE4MjA1NTAyMV5BMl5BanBnXkFtZTcwNzM1NDQyMQ@@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Elysium", Id = Guid.NewGuid(), Plot = "In the year 2154, the very wealthy live on a man-made space station while the rest of the population resides on a ruined Earth. A man takes on a mission that could bring equality to the polarized worlds." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BNDc2NjU0MTcwNV5BMl5BanBnXkFtZTcwMjg4MDg2OQ@@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Inception", Id = Guid.NewGuid(), Plot = "A thief who steals corporate secrets through use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "Raiders of the Lost Ark", Id = Guid.NewGuid(), Plot = "Archaeologist and adventurer Indiana Jones is hired by the US government to find the Ark of the Covenant before the Nazis." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMjA0ODEzMTc1Nl5BMl5BanBnXkFtZTcwODM2MjAxNA@@._V1_SX214_AL_.jpg" },
                new Movie() { Name = "The Godfather", Id = Guid.NewGuid(), Plot = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." , ReleaseDate = DateTime.Now, Runtime = 120, CoverLink="http://ia.media-imdb.com/images/M/MV5BMjEyMjcyNDI4MF5BMl5BanBnXkFtZTcwMDA5Mzg3OA@@._V1_SX214_AL_.jpg" },


            };

            genres.ForEach(genre => context.Genres.Add(genre));
            movies.ForEach(movie => context.Movies.Add(movie));
            context.SaveChanges();
        }
    }
}