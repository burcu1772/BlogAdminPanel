using System;
using Blog.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Infastructure
{
  public  interface ICategoryRepository : IRepository<Category>
    {
    }
}
