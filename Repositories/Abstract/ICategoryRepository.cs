using Product_Mini.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        bool AddUpdate(Category category);
        bool Delete(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
    }
}
