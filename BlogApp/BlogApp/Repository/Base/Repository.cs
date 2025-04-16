using Microsoft.EntityFrameworkCore;
using BlogApp.Contexts;
using BlogApp.Models;
using BlogApp.Repository.Interfaces;

namespace RepositoryDesignPattern.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        BlogAppContext _context;
        protected DbSet<T> table;

        public Repository(BlogAppContext context)
        {
            _context = context;
            table = context.Set<T>();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
        public void Create(T entity)
        {
            table.Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            table.Remove(entity);
            Save();
        }

        public void Edit(T entity)
        {
            table.Update(entity);
            Save();
        }
     
        public T GetById(int id)
        {
            return table.Find(id);
        }
    }
}
