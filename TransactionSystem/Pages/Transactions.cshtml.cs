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
            // Sprawdzenie czy u¿ytkownik jest zalogowany
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Jeœli u¿ytkownik nie jest zalogowany, przekierowanie na stronê logowania
                  Response.Redirect("./Index");
            }
            else
            {
                // Jeœli u¿ytkownik jest zalogowany, pobierz jego nazwê u¿ytkownika z sesji
                Username = HttpContext.Session.GetString("Username");
            }
        }

        public void OnPostAddTransaction()
        {
            // Tutaj mo¿na umieœciæ kod dodawania transakcji, np. wywo³anie odpowiedniego API

            // Po dodaniu transakcji mo¿na zaktualizowaæ listê produktów
            DataStore.Transactions.Add(Transaction);
        }
    }
}
