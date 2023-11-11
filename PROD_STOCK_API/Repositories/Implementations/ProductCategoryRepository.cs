using Microsoft.EntityFrameworkCore;
using PROD_STOCK_API.DTOs;
using PROD_STOCK_API.DTOs.ProductCategory;
using PROD_STOCK_API.Entities;
using PROD_STOCK_API.Exceptions;
using PROD_STOCK_API.Repositories.Interfaces;

namespace PROD_STOCK_API.Repositories.Implementations
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ProductCategoryDto ConvertToDto(ProductCategory item)
        {
            return new ProductCategoryDto
            {
                Id = item.Id,
                Description = item.Description,
                Active = item.Active,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            };
        }

        private SelectResultDto ConvertToSelectResultDto(ProductCategory item)
        {
            return new SelectResultDto
            {
                Value = item.Id,
                Label = $"{item.Id} - {item.Description}",
            };
        }

        private async Task<ProductCategory?> GetItem(int id)
        {
            var item = await _dbContext.ProductCategories.FindAsync(id);
            return item;
        }

        private void VerifyDto(ProductCategoryDto dto)
        {
            var fieldsErros = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Description))
                fieldsErros.Add("description");

            if (fieldsErros.Count > 0)
                throw new ValidationException(fieldsErros);
        }

        public async Task<ProductCategoryDto> GetByIdAsync(int id)
        {
            var productCategory = await GetItem(id);
            if (productCategory == null)
                throw new Exception("Produto Categoria não encontrado");

            return ConvertToDto(productCategory);
        }

        public async Task<PaginationResultDto<ProductCategoryDto>> GetAllAsync(FilterPaginationDto filter)
        {
            var dbQuery = _dbContext.ProductCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = $"%{filter.Search.Replace(" ", "%")}%";
                dbQuery = dbQuery.Where(x => x.Id.ToString().Equals(search) ||
                                             x.Description.Equals(search));
            }

            var totalItems = await dbQuery.CountAsync();

            if (filter.CurrentPage != null && filter.PageSize != null)
                dbQuery = dbQuery.Skip(filter.CurrentPage.Value * filter.PageSize.Value).Take(filter.PageSize.Value);

            var list = dbQuery.ToList().Select(x => ConvertToDto(x)).ToList();

            return new PaginationResultDto<ProductCategoryDto>
            {
                Data = list,
                CurrentPage = filter.CurrentPage ?? 0,
                PageSize = filter.PageSize ?? 0,
                TotalItems = totalItems
            };
        }

        public async Task<int> CreateAsync(ProductCategoryDto dto)
        {
            VerifyDto(dto);
            var newItem = new ProductCategory();

            newItem.Description = dto.Description;
            newItem.Active = dto.Active ?? true;
            newItem.CreatedAt = DateTime.Now;

            _dbContext.ProductCategories.Add(newItem);
            await _dbContext.SaveChangesAsync();
            return newItem.Id;
        }

        public async Task<int> UpdateAsync(ProductCategoryDto dto, int id)
        {
            var item = await GetItem(id);
            if (item == null)
                throw new Exception("Produto Categoria não encontrado!");

            VerifyDto(dto);
            var newItem = new ProductCategory();

            item.Description = dto.Description;
            item.Active = dto.Active ?? false;
            item.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetItem(id);
            if (item == null)
                throw new Exception("Produto Categoria não encontrado!");

            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SelectResultDto>> GetSelectAsync(FilterSelectDto filter)
        {
            var dbQuery = _dbContext.ProductCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = $"%{filter.Search.Replace(" ", "%")}%";
                dbQuery = dbQuery.Where(x => x.Id.ToString().Equals(search) ||
                                             x.Description.Equals(search));
            }

            var list = await dbQuery.Select(x => ConvertToSelectResultDto(x)).ToListAsync();
            return list;
        }
    }
}
