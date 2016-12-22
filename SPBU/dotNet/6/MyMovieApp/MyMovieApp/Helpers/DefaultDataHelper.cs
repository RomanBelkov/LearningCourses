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

            var movieData = new[] {
                new { Name = "Побег из Шоушенка", Year = 1994, Country = "США", Image = "326.jpg",
                    Director = frank, Actors = new[] { robbins, freeman } },

                new { Name = "Бэтмен: Начало", Year = 2005, Country = "США",  Image = "47237.jpg",
                    Director = nolan, Actors = new[] { freeman } },

                new { Name = "Зеленая миля", Year = 1999, Country = "США", Image = "435.jpg",
                    Director = frank, Actors = new[] { hanks }},

                new { Name = "Спасти рядового Райана", Year = 1998, Country = "США", Image = "371.jpg",
                    Director = spilberg, Actors = new[] { hanks, burns } },

                new { Name = "Однажды в Америке", Year = 1983, Country = "Италия", Image = "469.jpg",
                    Director = leone, Actors = new[] { deniro } },

                new { Name ="Семь", Year = 1995, Country = "США", Image="377.jpg",
                    Director = fincher, Actors = new[] { freeman, pitt } },

                new { Name ="Бойцовский клуб", Year = 1999, Country = "США", Image="361.jpg",
                    Director = fincher, Actors = new[] { pitt, norton } },

                new { Name ="Американская история Х", Year = 1998, Country = "США", Image="382.jpg",
                    Director = tkey, Actors = new[] { norton } },

                new { Name ="Леон", Year = 1994, Country = "Франция", Image="389.jpg",
                    Director = besson, Actors = new[] { reno, oldman } },

            };

            await directorRepository.Add(frank);
            await directorRepository.Add(nolan);
            await directorRepository.Add(spilberg);

            await actorRepository.Add(robbins);
            await actorRepository.Add(freeman);
            await actorRepository.Add(hanks);
            await actorRepository.Add(burns);

            var imagesBaseDir = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\DefaultPictures\"));
            for (var i = 0; i < movieData.Length; i++)
            {
                await movieRepository.Add(new Movie
                {
                    //Id = i + 1,
                    Name = movieData[i].Name,
                    Year = movieData[i].Year,
                    FilmingCountry = movieData[i].Country,
                    ImageUrl = imagesBaseDir + movieData[i].Image,
                    Director1 = movieData[i].Director,
                    Actors = movieData[i].Actors,

                });
            }

            
        }
    }
}
