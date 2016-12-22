using System.Threading.Tasks;

namespace MyMovieApp.Autocompletes
{
    internal interface IAutocomplete
    {
        Task<string[]> Complete(string s);
    }
}
