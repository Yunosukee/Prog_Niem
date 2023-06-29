using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TransactionSystem.Controllers;
using TransactionSystem.Models;

namespace TransactionSystem.Pages
{
    public class TransactionsModel : PageModel
    {

        public UserController userController = new UserController();
        public ProductController productController = new ProductController();
        public TransactionController transactionController = new TransactionController();

        public string Username { get; set; }
        [BindProperty]
        public Transaction transactions { get; set; }

        public List<User> users { get; set; }
        public List<ProductWithID> products { get; set; }
        public List<TransactionWithID> transactionWithIDs { get; set; }
        public List<TransactionExtra> transactionExtra { get; set; }

        public async Task<IActionResult> OnGet() 
        {
            products = await productController.GetProducts();
            users = await userController.GetUsers();
            transactionWithIDs = await transactionController.GetTransactions();
            transactionExtra = await transactionController.GetTransactionsExtra();


            // Sprawdzenie czy u�ytkownik jest zalogowany
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Je�li u�ytkownik nie jest zalogowany, przekierowanie na stron� logowania
                  Response.Redirect("./Index");
            }
            else
            {
                // Je�li u�ytkownik jest zalogowany, pobierz jego nazw� u�ytkownika z sesji
                Username = HttpContext.Session.GetString("Username");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddTransaction()
        {
            // Tutaj mo�na umie�ci� kod dodawania transakcji, np. wywo�anie odpowiedniego API

            // Po dodaniu transakcji mo�na zaktualizowa� list� produkt�w
            await transactionController.AddTransaction(transactions);

            return RedirectToPage("/Transactions");
        }

        public async Task<IActionResult> OnPostDeleteTransaction(string Id)
        {
            int number = int.Parse(Id);
            await transactionController.DeleteTransaction(number);

            return RedirectToPage("/Transactions");
        }
    }
}
