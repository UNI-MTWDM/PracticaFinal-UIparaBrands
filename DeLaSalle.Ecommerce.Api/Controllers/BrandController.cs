using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class BrandController : ControllerBase
{

    private IBrandService _service;

    public BrandController(IBrandService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<BrandDto>>>> GetAll()
    {
        var response = new Response<List<BrandDto>>
        {
            Data = await _service.GetAllAsync()
        };
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDto>>> GetById(int id)
    {
        var response = new Response<BrandDto?>();
        if (!await _service.BrandExists(id))
        {
            response.Errors.Add("Bran Not Found");
            return NotFound(response);
        }

        response.Data = await _service.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<BrandDto>>> Post([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>()
        {
            Data = await _service.SaveAsync(brandDto)
        };
        
        return Created($"api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<BrandDto>>> Put([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto?>();
        if (!await _service.BrandExists(brandDto.Id))
        {
            response.Errors.Add("Bran Not Found");
            return NotFound(response);
        }

        response.Data = await _service.UpdateAsync(brandDto);
        return Ok(response);

    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Brand>>> Delete(int id)
    {
        var response = new Response<bool>
        {
            Data = await _service.DeleteAsync(id)
        };

        return Ok(response);

    }

}