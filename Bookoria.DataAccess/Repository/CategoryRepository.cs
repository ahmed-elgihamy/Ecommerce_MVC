using Bookoria.DataAccess.Repository.IRepository;
using Bookoria.DataAcess.Data;
using Bookoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookoria.DataAccess.Repository
{
 public  class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
  

        public void Update(Category category)
        {
            _dbContext.Update(category);
        }
    }
}
