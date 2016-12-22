using System.Collections.Generic;

namespace MyMovieApp.Models
{
    internal sealed class MoviesGrid
    {
        internal delegate void StateChangedEvent(MoviesGrid instance);
        internal event StateChangedEvent StateChanged;

        private List<Movie> _movies = new List<Movie>();
        internal List<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                Update();
            }
        }

        internal List<Actor> Actors { get; } = new List<Actor>();

        internal void AddMovie(Movie movie)
        {
            _movies.Add(movie);
            Update();
        }

        internal void AddMovieRange(Movie[] movies)
        {
            _movies.AddRange(movies);
            Update();
        }

        private void Update() => StateChanged?.Invoke(this);
    }
}
