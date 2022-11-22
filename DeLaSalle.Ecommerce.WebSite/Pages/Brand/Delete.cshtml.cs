using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebSite.Pages.Brand;

public class Delete : PageModel
{
    [BindProperty]public BrandDto Brand { get; set; }
    
    private readonly IBrandService _service;

    public Delete(IBrandService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        Brand = new BrandDto();
        if (id.HasValue)
        {
            var response = await _service.GetById(id.Value);
            Brand = response.Data;
        }
        if (Brand == null)
        {
            return RedirectToPage("/Error");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(Brand.Id);

        return RedirectToPage("./List");
    }
}