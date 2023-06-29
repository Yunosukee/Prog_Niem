using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransactionSystem.Controllers;

namespace TransactionSystem.Pages
{
    public class AddProductModel : PageModel
    {
        public ProductController productController = new ProductController();

        [BindProperty]
        public Product product { get; set; }

        public List<ProductWithID> products { get; set; }

        public async Task<IActionResult> OnGet()
        {
            products = await productController.GetProducts();

            if (HttpContext.Session.GetString("Admin") != null)
            {
                // Jeœli u¿ytkownik nie jest zalogowany, przekierowanie na stronê logowania

                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }


        public async Task<IActionResult> OnPostAddProduct(Product product)
        {
            await productController.AddProduct(product);

            return RedirectToPage("/AddProduct");
        }
        public async Task<IActionResult> OnPostDelete(string Id)
        {
            int number = int.Parse(Id);
            await productController.DeleteProductWithId(number);
            return RedirectToPage();
        }
    }
}
