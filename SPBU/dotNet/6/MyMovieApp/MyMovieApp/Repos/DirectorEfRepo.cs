using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp.Repos
{
    internal sealed class DirectorEfRepo : EfRepo<Director>
    {
        public DirectorEfRepo(DbSet<Director> dbSet, DataModelContainer dbContainer) : base(dbSet, dbContainer)
        {
        }

        public override async Task<bool> Add(Director entity)
        {
            if (await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync() == null)
            {
                DbSet.Add(entity);
            }
            await DbContainer.SaveChangesAsync();
            return true;
        }

        public override IQueryable<Director> TextSearch(string s)
        {
            return DbSet.Where(x => SqlFunctions.PatIndex(s, x.Name) > 0);
        }
    }
}
