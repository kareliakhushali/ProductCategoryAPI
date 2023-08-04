using Product_Mini.Models.Domain;
using Product_Mini.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            this._context = context;

        }
        public bool AddUpdate(Category category)
        {
            try
            {
                if (category.Id == 0)
                   _context.Category.Add(category); 
                else
                   _context.Category.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var record = GetById(id);
                if (record == null)
                    return false;
                _context.Category.Remove(record);
                _context.SaveChanges();
                return true;
               

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.Find(id);
        }
    }
}
