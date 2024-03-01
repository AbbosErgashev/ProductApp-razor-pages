using AutoMapper;
using ProductApp.Business.IService;
using ProductApp.Business.Models.ProductModel;
using ProductApp.Infrastructure.Entity;
using ProductApp.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadProductModel> CreateProduct(CreateProductModel model)
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentNullException(nameof(model));
            }
            var create = _mapper.Map<Product>(model);
            await _repository.CreateProduct(create);
            var mapped = _mapper.Map<ReadProductModel>(create);
            return mapped;
        }

        public async Task DeleteProductById(int id)
        {
            var delete = await _repository.GetByIdProduct(id);
            if (delete is null)
            {
                throw new ArgumentNullException(nameof(delete));
            }
            await _repository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ReadProductModel>> GetAllProducts()
        {
            var entity = await _repository.GetAllProducts();
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var mapped = _mapper.Map<IEnumerable<ReadProductModel>>(entity);
            return mapped;
        }

        public async Task<ReadProductModel> GetProductById(int id)
        {
            var entity = await _repository.GetByIdProduct(id);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var mapped = _mapper.Map<ReadProductModel>(entity);
            return mapped;
        }

        public async Task UpdateProduct(UpdateProductModel model)
        {
            var entity = await _repository.GetByIdProduct(model.Id);
            if(entity is null)
            {
                throw new ArgumentException("Product not found");
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentNullException(nameof(model), "Name cannot null or empty");
            }
            await _repository.UpdateProduct(entity);
            _mapper.Map(model, entity);
            await _repository.SaveChangesAsync();
        }
    }
}
