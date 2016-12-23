using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMovieApp.Repos;

namespace MyMovieApp.Helpers
{
    internal sealed class DefaultDataHelper
    {
        internal static async Task FillRepositories(
            IRepo<Movie> movieRepository,
            IRepo<Director> directorRepository,
            IRepo<Actor> actorRepository)
        {
            var frank = new Director { Name = "Фрэнк Дарабонт" };
            var nolan = new Director { Name = "Кристофер Нолан" };
            var spilberg = new Director { Name = "Стивен Спилберг" };
            var leone = new Director { Name = "Серджио Леоне" };
            var fincher = new Director { Name = "Дэвид Финчер" };
            var tkey = new Director { Name = "Тони Кэй" };
            var besson = new Director { Name = "Люк Бессон" };

            var robbins = new Actor { Name = "Тим Роббинс" };
            var freeman = new Actor { Name = "Морган Фриман" };
            var hanks = new Actor { Name = "Том Хэнкс" };
            var burns = new Actor { Name = "Эдвард Бёрнс" };
            var deniro = new Actor { Name = "Роберт Де Ниро" };
            var pitt = new Actor { Name = "Брэд Питт" };
            var norton = new Actor { Name = "Эдвард Нортон" };
            var reno = new Actor { Name = "Жан Рено" };
            var oldman = new Actor { Name = "Гари Олдман" };

            var movieData = new List<Movie> {
                new Movie { Name = "Побег из Шоушенка", Year = 1994, FilmingCountry = "США", ImageUrl = "326.jpg",
                    Director1 = frank, Actors = new List<Actor> { robbins, freeman } },

                new Movie { Name = "Бэтмен: Начало", Year = 2005, FilmingCountry= "США",  ImageUrl = "47237.jpg",
                    Director1 = nolan, Actors = new List<Actor> { freeman } },

                new Movie { Name = "Зеленая миля", Year = 1999, FilmingCountry= "США", ImageUrl = "435.jpg",
                    Director1 = frank, Actors = new List<Actor> { hanks }},

                new Movie { Name = "Спасти рядового Райана", Year = 1998, FilmingCountry = "США", ImageUrl = "371.jpg",
                    Director1 = spilberg, Actors = new List<Actor> { hanks, burns } },

                new Movie { Name = "Однажды в Америке", Year = 1983, FilmingCountry = "Италия", ImageUrl = "469.jpg",
                    Director1 = leone, Actors = new List<Actor> { deniro } },

                new Movie { Name ="Семь", Year = 1995, FilmingCountry = "США", ImageUrl="377.jpg",
                    Director1 = fincher, Actors = new List<Actor> { freeman, pitt } },

                new Movie { Name ="Бойцовский клуб", Year = 1999, FilmingCountry = "США", ImageUrl="361.jpg",
                    Director1 = fincher, Actors = new List<Actor> { pitt, norton } },

                new Movie { Name ="Американская история Х", Year = 1998, FilmingCountry = "США", ImageUrl="382.jpg",
                    Director1 = tkey, Actors = new List<Actor> { norton } },

                new Movie { Name ="Леон", Year = 1994, FilmingCountry = "Франция", ImageUrl="389.jpg",
                    Director1 = besson, Actors = new List<Actor> { reno, oldman } },

            };

            await directorRepository.Add(frank);
            await directorRepository.Add(nolan);
            await directorRepository.Add(spilberg);

            await actorRepository.Add(robbins);
            await actorRepository.Add(freeman);
            await actorRepository.Add(hanks);
            await actorRepository.Add(burns);

            var imagesBaseDir = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\DefaultPictures\"));
            for (var i = 0; i < movieData.Count; i++)
            {
                await movieRepository.Add(new Movie
                {
                    //Id = i + 1,
                    Name = movieData[i].Name,
                    Year = movieData[i].Year,
                    FilmingCountry = movieData[i].FilmingCountry,
                    ImageUrl = imagesBaseDir + movieData[i].ImageUrl,
                    Director1 = movieData[i].Director1,
                    Actors = movieData[i].Actors,

                });
            }

            
        }
    }
}
