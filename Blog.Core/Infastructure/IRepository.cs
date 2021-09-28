using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.Infastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        T Get(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetByName(string name);
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        int InsertAndGetId(T entity);
        void Update(T entity);
        T UpdateAndGet(T entity);

        void Delete(T entity);
        //int Save();



    }
}
