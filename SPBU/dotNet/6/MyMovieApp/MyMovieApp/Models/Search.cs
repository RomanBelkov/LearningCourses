namespace MyMovieApp.Models
{
    internal sealed class Search
    {
        internal delegate void StateChangedEvent(Search instance);
        internal event StateChangedEvent StateChanged;

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

        private string _country;
        internal string Country
        {
            get { return _country; }
            set
            {
                _country = value;
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

        private string _director;
        internal string Director
        {
            get { return _director; }
            set
            {
                _director = value;
                Update();
            }
        }

        private string _actor;
        internal string Actor
        {
            get { return _actor; }
            set
            {
                _actor = value;
                Update();
            }
        }

        private void Update() => StateChanged?.Invoke(this);
    }
}
