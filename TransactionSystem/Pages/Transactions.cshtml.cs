using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransactionSystem.Pages
{
    public class TransactionsModel : PageModel
    {
        public string Username { get; set; }
        [BindProperty]
        public Transaction Transaction { get; set; }

        public void OnGet()
        {
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
        }

        public void OnPostAddTransaction()
        {
            // Tutaj mo�na umie�ci� kod dodawania transakcji, np. wywo�anie odpowiedniego API

            // Po dodaniu transakcji mo�na zaktualizowa� list� produkt�w
            DataStore.Transactions.Add(Transaction);
        }
    }
}
