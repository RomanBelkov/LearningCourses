using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyMovieApp.Repos;

namespace MyMovieApp.Autocompletes
{
    internal sealed class ActorsAutocomplete : IAutocomplete
    {
        private readonly IRepo<Actor> _repo;

        internal ActorsAutocomplete(IRepo<Actor> repo)
        {
            _repo = repo;
        }

        public Task<string[]> Complete(string s)
        {
            return _repo.TextSearch(s).Select(actor => actor.Name).ToArrayAsync();
        }
    }
}
