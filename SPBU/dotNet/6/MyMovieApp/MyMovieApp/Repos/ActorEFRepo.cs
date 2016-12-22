using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp.Repos
{
    internal sealed class ActorEfRepo : EfRepo<Actor>
    {
        public ActorEfRepo(DbSet<Actor> dbSet, DataModelContainer dbContainer) : base(dbSet, dbContainer)
        {
        }

        public override async Task<bool> Add(Actor entity)
        {
            if (await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync() == null)
            {
                DbSet.Add(entity);
            }
            await DbContainer.SaveChangesAsync();
            return true;
        }

        public override IQueryable<Actor> TextSearch(string s)
        {
            return DbSet.Where(x => SqlFunctions.PatIndex(s, x.Name) > 0);
        }
    }
}
