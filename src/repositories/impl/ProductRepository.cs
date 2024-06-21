using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.repositories.impl {
    public class ProductRepository : IProductRepository {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) {
            _context = context;
        }

        public bool ExistProductById(Guid id) {
            return _context.Products.Any(n => n.Id == id);
        }

        public async Task<ProductEntity> FindProductById(Guid id) {
            return await _context.Products
                        .Include(p => p.Photos)
                        .Include(p => p.Categories)
                        .Include(p => p.Options)
                        .FirstOrDefaultAsync(x => x.Id == id)
                        ?? throw new NotFoundException(
                            message: ErrorMessage.PRODUCT_NOT_FOUND
                        );
        }

        public async Task<List<ProductEntity>> GetAll() {
            return await _context.Products.ToListAsync();
        }
    }
}