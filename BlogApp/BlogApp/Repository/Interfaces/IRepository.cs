using BlogApp.Models;

namespace BlogApp.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);

        T GetById(int id);

        void Edit(T entity);

        void Delete(int id);
    }
}
