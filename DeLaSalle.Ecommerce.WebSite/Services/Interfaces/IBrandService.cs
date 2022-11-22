using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;

namespace DeLaSalle.Ecommerce.WebSite.Services.Interfaces;

public interface IBrandService
{
    Task<Response<List<BrandDto>>> GetAllAsync();
    Task<Response<BrandDto>> GetById(int id);
    Task<Response<BrandDto>> SaveAsync(BrandDto brandDto);
    Task<Response<BrandDto>> UpdateAsync(BrandDto brandDto);
    Task<Response<bool>> DeleteAsync(int id);
}