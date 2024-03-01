using ProductApp.Infrastructure.Entity;
using ProductApp.Infrastructure.IRepository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.IRepository
{
    public interface IProductRepository : IBaseRepo
    {
        Task<ICollection<Product>> GetAllProducts();
        Task<Product> GetByIdProduct(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
