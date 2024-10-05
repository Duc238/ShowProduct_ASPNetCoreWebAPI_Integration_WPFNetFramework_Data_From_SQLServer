using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShowProductFromAPI.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _ProductList;
        public ObservableCollection<Product> ProductList { get=> _ProductList; set { _ProductList = value;OnPropertyChanged(); } }
        private static readonly HttpClient client = new HttpClient();
        public MainViewModel()
        {
            ShowProducts();
        }
        public async void ShowProducts()
        {
            var products = await GetProductsFromApi();
            if(products!=null)
            {
                ProductList = new ObservableCollection<Product>(products);
            }
        }
        private async Task<List<Product>> GetProductsFromApi()
        {
            try
            {
                // Calling API and getting the response
                HttpResponseMessage response = await client.GetAsync("https://localhost:7174/api/Product");

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response body as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to a list of Product objects
                return JsonConvert.DeserializeObject<List<Product>>(responseBody);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");
                return new List<Product>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return new List<Product>();
            }
        }
    }
}
