using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TransactionSystem.Pages;

namespace TransactionSystem.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddUser(Customer userDto)
        {
 
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Customer";
            // Wykonaj walidację danych użytkownika
            if (ModelState.IsValid)
            {
                HttpContent httpContent = JsonContent.Create(userDto);
                // Wykonaj żądanie HTTP do endpointu API, który obsługuje dodawanie użytkownika
                var response = await httpClient.PostAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    // Dodawanie użytkownika powiodło się, wykonaj odpowiednie akcje
                    // ...

                    return RedirectToAction("Index", "Home"); // Przekierowanie po sukcesie
                }
                else
                {
                    // Dodawanie użytkownika nie powiodło się, odczytaj treść odpowiedzi i obsłuż błędy
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć formularz z błędami walidacji
            return RedirectToPage("/AddUser");
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Customer/";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                List<User>? users = await response.Content.ReadFromJsonAsync<List<User>>();
                foreach (User user in users)
                {
                    // Przykład: Wyświetlanie danych użytkownika
                    //Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                }
                //Console.WriteLine(users);
                return users;
            }
            else
            {
                throw new Exception("Brak obiektów w liście");
            }
        }

        [HttpDelete]
        public async Task DeleteUserWithId(int userID)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Customer/" + userID;
            HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(User user)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Customer";

            if (ModelState.IsValid)
            {
                HttpContent httpContent = JsonContent.Create(user);
                var response = await httpClient.PutAsync(apiUrl, httpContent);
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
    }
}
