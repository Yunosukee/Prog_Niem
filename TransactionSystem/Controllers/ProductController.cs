using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TransactionSystem.Controllers
{
    public class ProductController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {

            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Product";

            if (ModelState.IsValid)
            {
                HttpContent httpContent = JsonContent.Create(product);
                var response = await httpClient.PostAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }

            return RedirectToPage("/AddProduct");

        }

        [HttpGet]
        public async Task<List<ProductWithID>> GetProducts()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Product/";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                List<ProductWithID>? products = await response.Content.ReadFromJsonAsync<List<ProductWithID>>();
                return products;
            }
            else
            {
                throw new Exception("Brak obiektów w liście");
            }
        }

        [HttpDelete]
        public async Task DeleteProductWithId(int productId)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Product/" + productId;
            HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(ProductWithID productWithIDs)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = "http://czechulab.duckdns.org:32768/Product";

            if (ModelState.IsValid)
            {
                HttpContent httpContent = JsonContent.Create(productWithIDs);
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
