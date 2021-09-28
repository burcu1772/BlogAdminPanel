using Blog.Core.Infastructure;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.Repository
{
   public class PublicationRepository: IPublicationRepository
    {
        private Blog_Context context = new Blog_Context();

        public void Delete(Publication entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Publication Get(Expression<Func<Publication, bool>> expression)
        {
            //return context.Publication.Where(expression).Include(i => i.Category).FirstOrDefault();

            return context.Publication.Where(expression).FirstOrDefault();
        }

        public IEnumerable<Publication> GetAll()
        {
            //return context.Publication.Include(i => i.Category).ToList();

            return context.Publication.ToList();
        }


        public Publication GetById(int id)
        {
            //return context.Publication.Where(i => i.ID == id).Include(i => i.Category).FirstOrDefault();

            return context.Publication.Where(i => i.ID == id).FirstOrDefault();
        }

        public IEnumerable<Publication> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Publication> GetMany(Expression<Func<Publication, bool>> expression)
        {
            return context.Publication.Where(expression);
        }

        public void Insert(Publication entity)
        {
            entity.CreatedDate = DateTime.Now;
            context.Publication.Add(entity);
            context.SaveChanges();
        }

        public int InsertAndGetId(Publication entity)
        {

            context.Publication.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }



        public void Update(Publication entity)
        {
            context.Publication.Update(entity);
            context.SaveChanges();
        }
        public Publication UpdateAndGet(Publication entity)
        {
            context.Publication.Update(entity);
            context.SaveChanges();
            return entity;


        }
    }
}
