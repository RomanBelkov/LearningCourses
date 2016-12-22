using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMovieApp.Repos;
using static System.String;

namespace MyMovieApp.Helpers
{
    internal sealed class GetMoviesAsyncHelper : AsyncHelper<List<Movie>>
    {
        private readonly IRepo<Movie> _movieRepository;
        private readonly IRepo<Director> _directorRepository;
        private readonly IRepo<Actor> _actorRepository;

        internal GetMoviesAsyncHelper(
            IRepo<Movie> movieRepository,
            IRepo<Director> directorRepository,
            IRepo<Actor> actorRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
        }

        internal void GetMovies(string movieName, int year, string country, string director, string actor)
        {
            Started();
            Task.Run(async () =>
            {
                try
                {
                    var movies = IsNullOrEmpty(movieName) ? _movieRepository.GetAllSet()
                        : _movieRepository.TextSearch(movieName);
                    if (year > 0)
                    {
                        movies = movies.Where(movie => movie.Year == year);
                    }

                    if (!IsNullOrEmpty(director))
                    {
                        var directors = await _directorRepository.ToArrayAsync(_directorRepository.TextSearch(director));
                        movies = movies.Where(movie => directors.Contains(movie.Director1));
                    }

                    if (!IsNullOrEmpty(actor))
                    {
                        var actors = await _actorRepository.ToArrayAsync(_actorRepository.TextSearch(actor));
                        movies = movies.Where(movie => actors.Intersect(movie.Actors).Count() != 0);
                    }

                    var result = await _movieRepository.ToListAsync(movies);
                    Completed(result);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }
    }
}
