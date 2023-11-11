using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROD_STOCK_API.DTOs;
using PROD_STOCK_API.DTOs.ProductCategory;
using PROD_STOCK_API.Exceptions;
using PROD_STOCK_API.Repositories.Interfaces;

namespace PROD_STOCK_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Listing")]
        public async Task<ActionResult<ErrorResultDto>> Get(FilterPaginationDto filter)
        {
            try
            {
                var list = await _repository.GetAllAsync(filter);
                return Ok(list);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorResultDto>> GetById(int id)
        {
            try
            {
                var list = await _repository.GetByIdAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ErrorResultDto>> Create(ProductCategoryDto dto)
        {
            try
            {
                var list = await _repository.CreateAsync(dto);
                return Ok(list);
            }
            catch (ValidationException ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = true;
                error.Error = ex.Fields;

                return BadRequest(error);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ErrorResultDto>> Update(ProductCategoryDto dto, int id)
        {
            try
            {
                var list = await _repository.UpdateAsync(dto, id);
                return Ok(list);
            }
            catch (ValidationException ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = true;
                error.Error = ex.Fields;

                return BadRequest(error);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorResultDto>> Delete(int id)
        {
            try
            {
                var list = await _repository.DeleteAsync(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Select")]
        public async Task<ActionResult<ErrorResultDto>> GetSelect(FilterSelectDto dto)
        {
            try
            {
                var list = await _repository.GetSelectAsync(dto);
                return Ok(list);
            }
            catch (Exception ex)
            {
                var error = new ErrorResultDto();

                error.IsValidation = false;
                error.Error = ex.Message;

                return BadRequest(ex.Message);
            }
        }
    }
}
