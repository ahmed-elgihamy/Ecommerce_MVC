using Bookoria.DataAccess.Repository.IRepository;
using Bookoria.DataAcess.Data;
using Bookoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookoria.DataAccess.Repository
{
 public   class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }




        public void Update(Product obj)
        {
            _dbContext.products.Update(obj);
        }
    }
}
