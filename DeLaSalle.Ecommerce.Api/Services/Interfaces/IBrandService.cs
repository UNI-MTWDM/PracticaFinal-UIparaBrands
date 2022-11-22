using DeLaSalle.Ecommerce.Core.Dto;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    Task<bool> BrandExists(int id);
    Task<BrandDto> SaveAsync(BrandDto brandDto);
    Task<BrandDto> UpdateAsync(BrandDto brandDto);
    Task<List<BrandDto>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<BrandDto?> GetByIdAsync(int id);
}