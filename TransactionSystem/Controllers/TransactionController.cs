using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TransactionSystem.Models;

namespace TransactionSystem.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Transaction";

            if (ModelState.IsValid)
            {
                HttpContent httpContent = JsonContent.Create(transaction);
                var response = await httpClient.PostAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }

            return RedirectToPage("/Transactions");

        }

        [HttpGet]
        public async Task<List<TransactionWithID>> GetTransactions()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Transaction/";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                List<TransactionWithID>? transactions = await response.Content.ReadFromJsonAsync<List<TransactionWithID>>();
                return transactions;
            }
            else
            {
                throw new Exception("Brak obiektów w liście");
            }
        }

        [HttpGet]
        public async Task<List<TransactionExtra>> GetTransactionsExtra()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Transaction/EXTRA/";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                List<TransactionExtra>? transactions = await response.Content.ReadFromJsonAsync<List<TransactionExtra>>();
                return transactions;
            }
            else
            {
                throw new Exception("Brak obiektów w liście");
            }
        }

        [HttpDelete]
        public async Task DeleteTransaction(int transactionId)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Transaction/" + transactionId;
            HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
        }
    }
}
