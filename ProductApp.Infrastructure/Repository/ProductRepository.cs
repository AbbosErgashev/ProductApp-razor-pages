using Microsoft.EntityFrameworkCore;
using ProductApp.Infrastructure.Data;
using ProductApp.Infrastructure.Entity;
using ProductApp.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDataContext _context;
        public ProductRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdProduct(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var entity = await _context.Products.ToListAsync();
            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateProduct(Product product)
        {
            await _context.SaveChangesAsync();
        }
    }
}
