
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatRoomApp.Data.Models.GenericRepo
{
    public interface IGenericRepository<TEntity>
       where TEntity : EntityBase
    {
        IQueryable<TEntity> PrepareQuery();
        TEntity Find(int id);

        void Add(TEntity entity);
        int Save();
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : EntityBase
    {
        private readonly ChatRoomAppDbContext _dbContext;
        protected DbSet<TEntity> dbSet { get; init; }

        public GenericRepository(ChatRoomAppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = _dbContext.Set<TEntity>();
                
        }

        public IQueryable<TEntity> PrepareQuery() =>
            dbSet.AsQueryable();

        public TEntity Find(int id)
            => PrepareQuery().SingleOrDefault(x => x.Id == id);

        public void Add(TEntity entity) =>
            dbSet.Add(entity);



        public int Save()
            => _dbContext.SaveChanges();
    }
}
