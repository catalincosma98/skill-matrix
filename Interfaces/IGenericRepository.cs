using System.Linq.Expressions;

namespace SkillMatrix.Interfaces
{
    public interface IGenericRepository<T>
    {
        List<T> FindAll();
        List<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
