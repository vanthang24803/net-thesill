using System.Net;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.dtos.category;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.interfaces;
using Api.TheSill.src.repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.services {
    public class CategoryService : ICategoryService {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper, ICategoryRepository categoryRepository) {
            _context = context;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<List<CategoryResponse>>> Seeds() {
            List<CategoryResponse> result = [];

            foreach (var category in Categories) {
                if (_categoryRepository.ExistByName(category)) {
                    throw new BadRequestException(message: ErrorMessage.CATEGORY_NAME_EXISTED);
                }

                var newCategory = new CategoryEntity() {
                    Name = category,
                };

                _context.Categories.Add(newCategory);
                result.Add(_mapper.Map<CategoryResponse>(newCategory));
            }

            await _context.SaveChangesAsync();

            return new Response<List<CategoryResponse>>(HttpStatusCode.Created, result);
        }

        public async Task<Response<List<CategoryResponse>>> FindAll() {
            var categories = await _context.Categories.ToListAsync();

            var response = _mapper.Map<List<CategoryResponse>>(categories);

            return new Response<List<CategoryResponse>>(HttpStatusCode.OK, response);
        }

        public async Task<Response<CategoryResponse>> Create(CategoryRequest request) {
            CategoryEntity category = new() {
                Name = request.Name,
            };


            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<CategoryResponse>(category);

            return new Response<CategoryResponse>(HttpStatusCode.Created, result);
        }

        public async Task<Response<CategoryResponse>> Update(Guid id, CategoryRequest request) {
            var category = await _categoryRepository.FindOne(id);

            category.Name = request.Name;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<CategoryResponse>(category);

            return new Response<CategoryResponse>(HttpStatusCode.OK, result);

        }

        public async Task<Response<string>> Delete(Guid id) {

            var category = await _categoryRepository.FindOne(id);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return new Response<string>(HttpStatusCode.OK, "Deleted successfully!");

        }

        public async Task<Response<CategoryResponse>> GetOne(Guid id) {
            return new Response<CategoryResponse>(HttpStatusCode.OK, _mapper.Map<CategoryResponse>(await _categoryRepository.FindOne(id)));
        }

        private readonly HashSet<string> Categories = [
                "Tree",
                "Plant",
                "Planter",
                "Plant Care",
                "Garden & Patio",
                "Gifts",
                "Faux",
                "Orchids",
                "Blooms"
        ];

    }
}