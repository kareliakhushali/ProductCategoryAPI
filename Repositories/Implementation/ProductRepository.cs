using Product_Mini.Models.Domain;
using Product_Mini.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            this._context = context;
        }
        public bool AddUpdate(Product product)
        {
            try
            {
                if (product.Id == 0)
                    _context.Product.Add(product);
                else
                    _context.Product.Update(product);
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
                _context.Product.Remove(record);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Product> GetAll(string term = " ")
        {
            term = term.ToLower();
            // return _context.Product.ToList();
            var data = (from product in _context.Product
                        join
        category in _context.Category
      on product.CategoryId equals category.Id
                        where term == "" || product.Name.ToLower().StartsWith(term)
                        select new Product
                        {
                            Id = product.Id,
                            CategoryId = product.CategoryId,
                            Name = product.Name,
                            CategoryName = category.Name,
                            Price = product.Price
                        })
                        .ToList();
            return data;

        }

        public Product GetById(int id)
        {
            return _context.Product.Find(id);
        }
    }
}
