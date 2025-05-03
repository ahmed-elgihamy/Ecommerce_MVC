using Bookoria.DataAccess.Repository.IRepository;
using Bookoria.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookoria.DataAccess.Repository
{
  public class UnitOFWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }


        public UnitOFWork( ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;

            Category = new CategoryRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
        }



        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
