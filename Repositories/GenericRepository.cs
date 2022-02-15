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
        public List<T> FindAll()
        {
            return DataContext.Set<T>().AsNoTracking().ToList();
        }
        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DataContext.Set<T>().Where(expression).AsNoTracking().ToList();
        }
        public void Create(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            DataContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }
    }
}
