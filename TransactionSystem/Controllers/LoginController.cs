using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TransactionSystem.Controlers
{
    public class LoginController : ControllerBase
    {

        public async Task<User> LogIn(string Email)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Customer/" + Email;
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                User? user = JsonConvert.DeserializeObject<User>(responseBody);
                Console.WriteLine(user);
                return user;
            }
            else
            {
                // Obsłuż błąd odpowiedzi z API
                string responseBody = await response.Content.ReadAsStringAsync();
                User? user  = JsonConvert.DeserializeObject<User>(responseBody);
                Console.WriteLine(user);
                return user;

            }
        }
    }

}
