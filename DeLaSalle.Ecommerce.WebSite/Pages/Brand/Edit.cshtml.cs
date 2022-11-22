using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebSite.Pages.Brand;

public class Edit : PageModel
{
    [BindProperty]public BrandDto Brand { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IBrandService _service;
    
    public Edit(IBrandService service)
    {
        Brand = new BrandDto();
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
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<BrandDto> response;
        
        if (Brand.Id > 0)
        {
            // Update
            response = await _service.UpdateAsync(Brand);
        }
        else
        {
            // Insert 
            response = await _service.SaveAsync(Brand);
        }
        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }
        Brand = response.Data;
        return RedirectToPage("./List");
    }
}