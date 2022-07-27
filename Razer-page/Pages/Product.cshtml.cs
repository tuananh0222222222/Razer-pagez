using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razer_page.Model;
using Razer_page.Services;

namespace Razer_page.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ILogger<ProductModel> logger;
        public readonly ProductService productService;

        public ProductModel(ILogger<ProductModel> _logger, ProductService _productService)
        {
            logger = _logger;
            productService = _productService;
        }

        public Product pr { get; set; }

        public IActionResult OnGet(int? Id)
        {
            if (Id != null)
            {

                ViewData["Title"] = $"san pham la {Id.Value}";
                pr = productService.Find(Id.Value);
                return Page();

            }
            else
            {
                ViewData["Title"] = "danh sach sp";

                return Page();


            }
        }

        public async Task<IActionResult> OnGetLastProductAsync()
        {
            pr = productService.AllProduct().LastOrDefault();

            if (pr != null)
            {


                return Page();
            }
            else
            {
                return Content("khong thay ");
            }

        }


        public async Task<IActionResult> OnGetDeleteAsync()
        {
            productService.AllProduct().Clear();

            return RedirectToPage("Product");
        }

        public async Task<IActionResult> OnGetLoadAsync()
        {
            productService.LoadProduct();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? Id)
        {
            if (Id != null)
            {
                pr = productService.Find(Id.Value);

                if (pr != null)
                {
                   productService.AllProduct().Remove(pr);
                }
            }
            return RedirectToPage("Product", new { Id = string.Empty });
        }

    }
}
