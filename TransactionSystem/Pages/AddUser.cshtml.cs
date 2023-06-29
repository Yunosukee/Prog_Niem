using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransactionSystem.Controlers;
using TransactionSystem.Controllers;

namespace TransactionSystem.Pages.Admin
{
    public class AddUserModel : PageModel
    {

        public UserController userController = new UserController();

        [BindProperty]
        public Customer customer { get; set; }

        public List<User> users { get; set; }


        public async Task<IActionResult> OnGet()
        {
            users = await userController.GetUsers();

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

        public async Task<IActionResult> OnPostAddCustomer(Customer customer)
        {

            await userController.AddUser(customer);

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(string Id)
        {
            Console.WriteLine("dzia³a xd");
            Console.WriteLine(Id);
            int number = int.Parse(Id);

            Console.WriteLine(number);
            // Implementacja logiki edycji produktu w C#
            // Wywo³anie odpowiedniej metody, np. z API lub serwisu
            await userController.DeleteUserWithId(number);
            return RedirectToPage();
        }

    }
}
