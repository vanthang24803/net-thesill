using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.repositories.impl {
    public class CategoryRepository : ICategoryRepository {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) {
            _context = context;
        }

        public bool ExistByName(string name) {
            return _context.Categories.Any(n => n.Name == name);
        }

        public async Task<CategoryEntity> FindByName(string name) {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name) ?? throw new NotFoundException(ErrorMessage.CATEGORY_NOT_FOUND);

            return category;
        }

        public async Task<CategoryEntity> FindOne(Guid id) {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException(ErrorMessage.CATEGORY_NOT_FOUND);

            return category;
        }

    }
}