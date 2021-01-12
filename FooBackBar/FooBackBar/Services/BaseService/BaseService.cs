using FooBackBar.DatabaseContext;
using FooBackBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBackBar.Services.BaseService
{
    public interface IBaseService<T> where T : Entity
    {
        List<T> GetAll();
        IQueryable<T> GetAllQueryable();
        T GetSingle(Guid guid);
        IQueryable<T> GetSingleQueryable(Guid guid);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }

    public abstract class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected readonly Context _context;

        public BaseService(Context context)
        {
            _context = context;
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetSingle(Guid guid)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Guid == guid);
        }

        public IQueryable<T> GetSingleQueryable(Guid guid)
        {
            return _context.Set<T>().Where(x => x.Guid == guid);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entitites)
        {
            _context.Set<T>().RemoveRange(entitites);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }

    }
}
