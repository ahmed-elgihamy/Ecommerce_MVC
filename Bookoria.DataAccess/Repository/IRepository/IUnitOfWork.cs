using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookoria.DataAccess.Repository.IRepository
{
   public interface IUnitOfWork
    {

        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }

        public void SaveChanges();
    }
}
