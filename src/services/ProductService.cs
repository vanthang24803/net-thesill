using System.Net;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.dtos.product;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.interfaces;
using Api.TheSill.src.repositories;
using AutoMapper;

namespace Api.TheSill.src.services {
    public class ProductService : IProductService {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;

        private readonly IUploadService _uploadService;

        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public ProductService(ApplicationDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper, IUploadService uploadService) {
            _context = context;
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _uploadService = uploadService;
        }

        public async Task<Response<string>> Delete(Guid id) {
            var product = await _productRepository.FindProductById(id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return new Response<string>(HttpStatusCode.OK, "Product deleted successfully!");
        }

        public async Task<Response<List<ProductResponse>>> FindAll() {
            var products = await _productRepository.GetAll();
            return new Response<List<ProductResponse>>(HttpStatusCode.OK, _mapper.Map<List<ProductResponse>>(products));
        }

        public async Task<Response<ProductDetailResponse>> GetById(Guid id) {

            var product = await _productRepository.FindProductById(id);

            return new Response<ProductDetailResponse>(HttpStatusCode.OK, _mapper.Map<ProductDetailResponse>(product));
        }

        public async Task<Response<ProductResponse>> Save(IFormFile file, CreateProductRequest request) {
            ProductEntity product = new() {
                Name = request.Name,
            };

            foreach (var item in request.Categories) {
                var category = await _categoryRepository.FindByName(item.Name);
                product.Categories.Add(category);
            }

            var upload = await _uploadService.UploadPhotoAsync(file);

            if (upload.Error != null) {
                throw new BadRequestException(message: ErrorMessage.UPLOAD_FAIL);
            }

            product.Thumbnail = upload.SecureUrl.AbsoluteUri;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return new Response<ProductResponse>(HttpStatusCode.Created, _mapper.Map<ProductResponse>(product));
        }

        public async Task<Response<ProductDetailResponse>> Update(Guid id, UpdateProductRequest updateProductRequest) {

            var product = await _productRepository.FindProductById(id);

            product.Name = updateProductRequest.Name;
            product.Guide = updateProductRequest.Guide;
            product.Published = updateProductRequest.Published;
            product.Description = updateProductRequest.Description;

            await _context.SaveChangesAsync();

            return new Response<ProductDetailResponse>(HttpStatusCode.OK, _mapper.Map<ProductDetailResponse>(product));
        }
    }
}