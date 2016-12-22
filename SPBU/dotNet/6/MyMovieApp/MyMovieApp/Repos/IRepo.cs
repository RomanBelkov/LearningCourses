using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp.Repos
{
    public interface IRepo<T>
    {
        IQueryable<T> GetAllSet();
        Task<T[]> ToArrayAsync(IQueryable<T> query);
        Task<List<T>> ToListAsync(IQueryable<T> query);
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task DropDb();
        IQueryable<T> TextSearch(string s);
    }
}
