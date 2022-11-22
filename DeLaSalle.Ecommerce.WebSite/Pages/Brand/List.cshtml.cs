using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebSite.Pages.Brand;

public class ListModel : PageModel
{
    private readonly IBrandService _service;
    public List<BrandDto> Brand { get; set; }

    public ListModel(IBrandService service)
    {
        Brand = new List<BrandDto>();
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Brand = response.Data;

        return Page();
    }
}