using Api.TheSill.src.context;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.interfaces;

namespace Api.TheSill.src.services {
    public class ProductService : IProductService {

        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) {
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