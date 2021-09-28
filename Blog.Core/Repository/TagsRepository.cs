using System;
using Blog.Core.Infastructure;
using System.Collections.Generic;
using System.Text;
using Blog.Data.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Core.Repository
{
   public class TagsRepository:ITagsRepository
    {
        private Blog_Context context = new Blog_Context();

        public void Delete(Tags entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Tags Get(Expression<Func<Tags, bool>> expression)
        {
            return context.Tags.Where(expression).FirstOrDefault();
        }

        public IEnumerable<Tags> GetAll()
        {
            return context.Tags.ToList();
        }


        public Tags GetById(int id)
        {
            return context.Tags.Where(i => i.ID == id).FirstOrDefault();
        }

        public IEnumerable<Tags> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tags> GetMany(Expression<Func<Tags, bool>> expression)
        {
            return context.Tags.Where(expression);
        }

        public void Insert(Tags entity)
        {
            context.Tags.Add(entity);
            context.SaveChanges();
        }

        public int InsertAndGetId(Tags entity)
        {

            context.Tags.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }



        public void Update(Tags entity)
        {
            context.Tags.Update(entity);
            context.SaveChanges();
        }
        public Tags UpdateAndGet(Tags entity)
        {
            context.Tags.Update(entity);
            return entity;


        }
    }
}
