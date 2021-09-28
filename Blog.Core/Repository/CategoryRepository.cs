using Blog.Core.Infastructure;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private Blog_Context context = new Blog_Context();

        public void Delete(Category entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            return context.Category.Where(expression).FirstOrDefault();
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Category.ToList();
        }
   

        public Category GetById(int id)
        {
            return context.Category.Where(i => i.ID == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetMany(Expression<Func<Category, bool>> expression)
        {
            return context.Category.Where(expression);
        }

        public void Insert(Category entity)
        {
            context.Category.Add(entity);
            context.SaveChanges();
        }

        public int InsertAndGetId(Category entity)
        {
          
            context.Category.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

     

        public void Update(Category entity)
        {
            context.Category.Update(entity);
            context.SaveChanges();
        }
        public Category UpdateAndGet(Category entity)
        {
            context.Category.Update(entity);
            return entity;


        }
    }
}
