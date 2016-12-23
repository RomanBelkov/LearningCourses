using System.Collections.Generic;

namespace MyMovieApp.Models
{
    internal sealed class MoviesEditor
    {
        internal delegate void StateChangedEvent(MoviesEditor instance);
        internal event StateChangedEvent StateChanged;

        private int _movieId;
        internal int MovieId
        {
            get { return _movieId; }
            set
            {
                _movieId = value;
                Update();
            }
        }

        private string _name;
        internal string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Update();
            }
        }

        private int _year;
        internal int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                Update();
            }
        }

        private string _filmingCountry;
        internal string FilmingCountry
        {
            get { return _filmingCountry; }
            set
            {
                _filmingCountry = value;
                Update();
            }
        }

        private string _image;
        internal string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Update();
            }
        }

        private Director _director;
        internal Director Director
        {
            get { return _director; }
            set
            {
                _director = value;
                Update();
            }
        }

        private List<Actor> _actors;
        internal List<Actor> Actors
        {
            get { return _actors; }
            set
            {
                _actors = value;
                Update();
            }
        }

        internal void RemoveActorAt(int i)
        {
            if (i < 0) return;
            _actors.RemoveAt(i);
            Update();
        }

        private void Update()
        {
            StateChanged?.Invoke(this);
        }
    }
}
