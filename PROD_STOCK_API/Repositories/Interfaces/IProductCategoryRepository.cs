using PROD_STOCK_API.DTOs.ProductCategory;
using PROD_STOCK_API.DTOs;

namespace PROD_STOCK_API.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        public Task<ProductCategoryDto> GetByIdAsync(int id);
        public Task<PaginationResultDto<ProductCategoryDto>> GetAllAsync(FilterPaginationDto filter);
        public Task<int> CreateAsync(ProductCategoryDto dto);
        public Task<int> UpdateAsync(ProductCategoryDto dto, int id);
        public Task<bool> DeleteAsync(int id);
        public Task<List<SelectResultDto>> GetSelectAsync(FilterSelectDto filter);

    }
}
