using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Blog.Data.Models
{
    public class Blog_Context : DbContext
    {

        private readonly IConfiguration _configuration;



        public Blog_Context(IConfiguration configuration)

        {
            _configuration = configuration;
        }


        public Blog_Context(DbContextOptions options) : base(options)
        {
        }

        public Blog_Context()
        {

        }

        public Blog_Context(DbContextOptions<Blog_Context> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connect = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogAdminPanel;Integrated Security=True");
            }
        }



        #region DBSets

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Publication> Publication { get; set; }
        public DbSet<Category> Category { get; set; }

        #endregion
    }
}
