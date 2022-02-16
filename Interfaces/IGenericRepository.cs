using System.Linq.Expressions;

namespace SkillMatrix.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> EagerFindAll(string[] children);
        Task<List<T>> FindAll();
        Task<T?> FindById(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T?> Delete(long id);
    }
}
