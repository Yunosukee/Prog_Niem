using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransactionSystem.Pages
{
    public class AdminPanelModel : PageModel
    {
        public  IActionResult OnGet()
        {

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
    }
}
