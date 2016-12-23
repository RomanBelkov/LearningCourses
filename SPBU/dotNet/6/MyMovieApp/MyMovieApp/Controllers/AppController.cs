using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMovieApp.Helpers;
using MyMovieApp.Models;
using MyMovieApp.Repos;

namespace MyMovieApp.Controllers
{
    internal sealed class AppController
    {
        private MainForm _mainForm;
        private SearchForm _searchForm;

        private readonly MoviesGrid _moviesGrid;
        private readonly Search _search;
        private readonly MoviesEditor _moviesEditor;

        private IRepo<Movie> _movieRepo;
        private IRepo<Director> _directorRepo;
        private IRepo<Actor> _actorRepo;

        private readonly GetMoviesAsyncHelper _getMovies;

        internal AppController(DataModelContainer dbContainer)
        {
            InitializeRepositories(dbContainer);

            _moviesGrid = new MoviesGrid();
            _search = new Search();
            _moviesEditor = new MoviesEditor();

            _getMovies = new GetMoviesAsyncHelper(_movieRepo, _directorRepo, _actorRepo);
        }

        private void InitializeRepositories(DataModelContainer dbContainer)
        {
            _movieRepo = new MovieEfRepo(dbContainer.Movies, dbContainer);
            _directorRepo = new DirectorEfRepo(dbContainer.Directors, dbContainer);
            _actorRepo = new ActorEfRepo(dbContainer.Actors, dbContainer);
        }

        internal Form RenderMainView()
        {
            InitializeSearchForm();

            _mainForm = new MainForm(_moviesGrid);

            _mainForm.RepopulateDatabase += async () =>
            {
                await _movieRepo.DropDb();
                await _actorRepo.DropDb();
                await _directorRepo.DropDb();
                

                await DefaultDataHelper.FillRepositories(_movieRepo, _directorRepo, _actorRepo);

                GetMovies();
            };

            _mainForm.SaveMovie += SaveMovie;
            _mainForm.DeleteFilm += DeleteMovie;

            _mainForm.EditFilm += selected =>
            {
                if (selected.Count > 0)
                {
                    var movie = selected[0];
                    _moviesEditor.MovieId = movie.Id;
                    _moviesEditor.Name = movie.Name;
                    _moviesEditor.Year = movie.Year;
                    _moviesEditor.FilmingCountry = movie.FilmingCountry;
                    _moviesEditor.Image = movie.ImageUrl;
                    _moviesEditor.Actors = new List<Actor>(movie.Actors);
                    _moviesEditor.Director = movie.Director1;
                    _mainForm.ShowMovieEditForm(_moviesEditor);
                }
            };

            _mainForm.AddMovieActor += async name =>
            {
                var query = _actorRepo.GetAllSet().Where(actor => actor.Name == name);
                var foundActor = (await _actorRepo.ToListAsync(query)).FirstOrDefault();
                if (foundActor != null)
                {
                    if (_moviesEditor.Actors.Contains(foundActor)) return;
                    _moviesEditor.Actors.Add(foundActor);
                }
                else
                {
                    var newActor = new Actor { Name = name };
                    await _actorRepo.Add(newActor);
                    var actors = _moviesEditor.Actors;
                    actors.Add(newActor);
                    _moviesEditor.Actors = actors;
                }
            };

            _mainForm.FindFilm += () =>
            {
                if (_mainForm.IsDisposed)
                {
                    InitializeSearchForm();
                }
                _mainForm.Show();
                _mainForm.Activate();
                _mainForm.Left = _mainForm.Left + _mainForm.Width / 2 - _mainForm.Width / 2;
                _mainForm.FindMovieMenuItem.Checked = true;
                _mainForm.ExitMenuItem.Enabled = false;
            };

            _mainForm.GoBack += () =>
            {
                GetMovies();
                _mainForm.ShowMovieGrid();
            };

            _mainForm.AboutOpen += () =>
            {
                //var aboutView = new AboutView();
                //aboutView.ShowDialog();
            };

            _mainForm.DeleteActor += position =>
            {
                _moviesEditor.RemoveActorAt(position);
            };

            _getMovies.OnStarted += () =>
            {
                _mainForm.SetGridStatus(false);
                _mainForm.SetGridTitle(Properties.Resources.GridTitleLoading);
            };

            GetMovies();
            return _mainForm;
        }

        private async void SaveMovie()
        {
            _mainForm.SetControlsState(false);

            var id = _moviesEditor.MovieId;
            var model = (await _movieRepo.ToArrayAsync(_movieRepo.GetAllSet().Where(movie => movie.Id == id)))[0];

            string directorName;
            var actorNames = new List<string>();
            _mainForm.UpdateMoviesEditorState(_moviesEditor, out directorName, actorNames);

            var existing = await _directorRepo.ToArrayAsync(
                _directorRepo.GetAllSet().Where(director => director.Name == directorName));

            model.Name = _moviesEditor.Name;
            model.Year = _moviesEditor.Year;
            model.FilmingCountry = _moviesEditor.FilmingCountry;
            model.Director1 = existing.Length == 0 ? new Director { Name = directorName } : existing[0];
            model.Actors = _moviesEditor.Actors;

            if (model.Director1.Id < 1)
            {
                await _directorRepo.Add(model.Director1);
            }

            await _movieRepo.Add(model);

            _mainForm.SetControlsState(true);
        }

        private async void DeleteMovie(List<Movie> selected)
        {
            var confirmed = 
                (from t in selected
                 let name = t.Name
                 select MessageBox.Show(string.Format(Properties.Resources.ApproveDeleteMovie, t.Name), Properties.Resources.ApproveDeleteMovieCaption, 
                 MessageBoxButtons.YesNo)).All(res => !res.HasFlag(DialogResult.No));
            if (!confirmed) return;
            await Task.WhenAll(selected.Select(x => _movieRepo.Delete(x)).ToArray());
            GetMovies();
        }

        private void InitializeSearchForm()
        {
            _searchForm = new SearchForm(_search) {Visible = false};

            _searchForm.UserInput += (name, year, director, actor) =>
            {
                _search.Name = name;
                _search.Year = year;
                _search.Director = director;
                _search.Actor = actor;
            };

            _searchForm.Search += () =>
            {
                var name = _search.Name;
                var director = _search.Director;
                var actor = _search.Actor;
                GetMovies(name, _search.Year, _search.Country, director, actor);
                _mainForm.Activate();
            };

            _searchForm.Clear += () =>
            {
                _search.Name = "";
                _search.Director = "";
                _search.Actor = "";
            };

            _searchForm.FormClosed += (s, e) =>
            {
                _mainForm.FindMovieMenuItem.Checked = false;
                _mainForm.ExitMenuItem.Enabled = true;
            };
        }

        private void GetMovies(
            string movieName = null,
            int year = 0,
            string country = null,
            string director = null,
            string actor = null)
        {
            GetMoviesAsyncHelper.OnCompletedEventHandler onCompletedHandler = null;
            var isEmptySearch = string.IsNullOrEmpty(movieName)
                && year == 0
                && string.IsNullOrEmpty(country)
                && string.IsNullOrEmpty(director)
                && string.IsNullOrEmpty(actor);

            onCompletedHandler = movies =>
            {
                _getMovies.OnCompleted -= onCompletedHandler;
                _mainForm.Invoke(new Action(() =>
                {
                    _moviesGrid.Movies = movies;
                    _mainForm.SetGridTitle(isEmptySearch ?
                        Properties.Resources.GridTitleAllMovies :
                        string.Format(Properties.Resources.GridTitleSearchResult, movieName));
                    _mainForm.SetGridStatus(true);
                }));
            };
            _getMovies.OnCompleted += onCompletedHandler;
            _getMovies.GetMovies(movieName, year, country, director, actor);
        }
    }
}
