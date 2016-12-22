using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyMovieApp.Repos;

namespace MyMovieApp.Autocompletes
{
    //TODO merge with Actors
    internal sealed class DirectorsAutocomplete : IAutocomplete
    {
        private readonly IRepo<Director> _repo;
        internal DirectorsAutocomplete(IRepo<Director> repo)
        {
            _repo = repo;
        }

        public Task<string[]> Complete(string s)
        {
            return _repo.TextSearch(s).Select(director => director.Name).ToArrayAsync();
        }
    }
}
