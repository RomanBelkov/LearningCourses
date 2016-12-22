using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp.Repos
{
    internal abstract class EfRepo<T> : IRepo<T> where T : class 
    {
        protected DbSet<T> DbSet;
        protected DataModelContainer DbContainer;

        protected EfRepo(DbSet<T> dbSet, DataModelContainer dbContainer)
        {
            DbSet = dbSet;
            DbContainer = dbContainer;
        }

        public IQueryable<T> GetAllSet()
        {
            return DbSet;
        }

        public Task<T[]> ToArrayAsync(IQueryable<T> query)
        {
            return query.ToArrayAsync();
        }

        public Task<List<T>> ToListAsync(IQueryable<T> query)
        {
            return query.ToListAsync();
        }

        public abstract Task<bool> Add(T entity);

        public async Task<bool> Delete(T entity)
        {
            DbSet.Remove(entity);
            await DbContainer.SaveChangesAsync();
            return true;
        }

        public async Task DropDb()
        {
            DbSet.RemoveRange(DbSet);
            await DbContainer.SaveChangesAsync();
        }

        public abstract IQueryable<T> TextSearch(string s);
    }
}
