using Api.TheSill.src.context;
using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories.impl {
    public class ProductRepository : IProductRepository {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) {
            _context = context;
        }

        public bool ExistProductById(Guid id) {
            throw new NotImplementedException();
        }

        public ProductEntity FindProductById(Guid id) {
            throw new NotImplementedException();
        }
    }
}