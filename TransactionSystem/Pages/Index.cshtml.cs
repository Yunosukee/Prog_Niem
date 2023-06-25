using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransactionSystem.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public IActionResult OnPostLogIn()
        {
            // Sprawdzenie poprawności danych logowania
            if (User.Email == "admin" && User.Password == "admin")
            {
                HttpContext.Session.SetString("Username", User.Email);
                return RedirectToPage("./Transactions");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Drugi chuj.");
                return Page();
            }
        }
    }
}