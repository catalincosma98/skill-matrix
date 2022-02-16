using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Database;
using SkillMatrix.Interfaces;

namespace SkillMatrix.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext DataContext;

        public GenericRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<List<T>> EagerFindAll(string[] children)
        {
            try
            {
                IQueryable<T> query = DataContext.Set<T>();
                foreach (string entity in children)
                {
                    query = query.Include(entity);

                }
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<T>> FindAll()
        {
            return await DataContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> FindById(long id)
        {
            var entity = await DataContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<T> Create(T entity)
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Set<T>().Add(entity);
            await DataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Delete(long id)
        {
            var entity = await DataContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            DataContext.Set<T>().Remove(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

    }
}
