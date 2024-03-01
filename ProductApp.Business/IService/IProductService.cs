using ProductApp.Business.Models.ProductModel;
using ProductApp.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Business.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ReadProductModel>> GetAllProducts();
        Task<ReadProductModel> GetProductById(int id);
        Task<ReadProductModel> CreateProduct(CreateProductModel model);
        Task UpdateProduct(UpdateProductModel model);
        Task DeleteProductById(int id);
    }
}
