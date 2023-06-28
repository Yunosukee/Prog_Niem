using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using TransactionSystem.Controlers;

namespace TransactionSystem.Pages
{

    public class IndexModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        
        public LoginController loginController = new LoginController();
        private string userEmail;
        private string userPassword;
        private string userName;


        public async Task<IActionResult> OnPostLogIn()
        {
            if(User.Email == null)
            {
                ModelState.AddModelError(string.Empty, "Wprowadz dane użytkownika.");
                return Page();
            }

            if(User.Email == "admin" && User.Password == "admin")
            {
                HttpContext.Session.SetString("Admin", "true");
                HttpContext.Session.SetString("Username", "admin");
                return RedirectToPage("./AdminPanel");
            }

            User LoginUser = await loginController.LogIn(User.Email);
            
            if (LoginUser == null)
            {
                ModelState.AddModelError(string.Empty, "Nie znaleziono użytkownika.");
                return Page();
            }
            else
            {
                User firstUser = LoginUser;
                userName = firstUser.Name;
                userEmail = firstUser.Email;
                userPassword = firstUser.Password;
            }

            if (User.Email == userEmail && User.Password == userPassword)
            {
                HttpContext.Session.SetString("Username", userName);
                return RedirectToPage("./Transactions");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Chuj.");
                return Page();
            }
        }
    }
}