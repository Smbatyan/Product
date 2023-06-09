using AutoMapper;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Entities;
using Product.API.Exceptions;
using Product.API.Repositories;

namespace Product.API.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsAsync(int page, int pageSize)
        {
            IEnumerable<ProductEntity> products =
                await _productRepository.GetProductsAsync(page, pageSize);

            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<ProductResponse> GetProductAsync(int id)
        {
            ProductEntity product = await _productRepository.GetProductAsync(id);
            if (product is null)
            {
                throw new ResourceNotFoundException("Product not found");
            }

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> CreateProductAsync(CreateProductRequest req)
        {
            ProductEntity productEntity = await _productRepository.GetProductByNameAsync(req.Name);
            if (productEntity is not null)
            {
                throw new ResourceAlreadyExistsException("Product already exists");
            }

            ProductEntity product = _mapper.Map<ProductEntity>(req);

            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> UpdateProductAsync(UpdateProductRequest req)
        {
            ProductEntity product = await _productRepository.GetProductAsync(req.Id);
            if (product is null)
            {
                throw new ResourceNotFoundException("Product not found");
            }

            product.Name = req.Name;
            product.Available = req.Available;
            product.Price = req.Price;
            product.Description = req.Description;

            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }
    }
}