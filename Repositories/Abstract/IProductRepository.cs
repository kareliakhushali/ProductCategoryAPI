using Product_Mini.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Repositories.Abstract
{
    public interface IProductRepository
    {
        bool AddUpdate(Product Product);
        bool Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll(string term="");


    }
}
