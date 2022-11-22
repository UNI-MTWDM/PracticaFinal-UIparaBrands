using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> BrandExists(int id)
    {
        var brand = await _repository.GetById(id);
        return (brand != null);
    }

    public async Task<BrandDto> SaveAsync(BrandDto brandDto)
    {
        var brand = new Brand
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now,
        };

        brand = await _repository.SaveAsync(brand);
        brandDto.Id = brand.Id;

        return brandDto;
    }

    public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
    {
        var brand = await _repository.GetById(brandDto.Id);

        if (brand == null)
            throw new Exception("Brand Not Found");
        
        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.UpdatedBy = "";
        brand.UpdatedDate = DateTime.Now;

        await _repository.UpdateAsync(brand);

        return (brandDto);

    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var brands = await _repository.GetAllAsync();
        return brands.Select(c => new BrandDto(c)).ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<BrandDto?> GetByIdAsync(int id)
    {
        var brand = await _repository.GetById(id);
        if (brand == null)
            throw new Exception("Brand Not Found");
        return new BrandDto(brand);
    }
}