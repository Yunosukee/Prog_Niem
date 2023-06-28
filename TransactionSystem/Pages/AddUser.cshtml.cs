using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransactionSystem.Pages.Admin
{
    public class AddUserModel : PageModel
    {

        [BindProperty]
        public User User { get; set; }

        public AddUserModel()
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {

            return Page();
        }
    }
}
