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
                // Je�li u�ytkownik nie jest zalogowany, przekierowanie na stron� logowania
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }

              
        }
    }
}
