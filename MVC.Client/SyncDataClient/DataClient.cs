using AutoMapper;
using IdentityModel.Client;
using MVC.Client.Infrastructure;
using MVC.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Client.SyncDataClient
{
    public class DataClient: IDataClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public DataClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        // Get Catalogs
        public async Task<IEnumerable<CatalogProduct>> GetCatalog()
        {
            //return new List<CatalogProduct>()
            //{
            //    new CatalogProduct {Id = 1, Name = "Chocolate Chip", UnitPrice = 2.5m, AvailableQuantity = 2},
            //    new CatalogProduct {Id = 2,Name = "Fried Cookie", UnitPrice = 2.75m, AvailableQuantity = 5},
            //    new CatalogProduct {Id = 3,Name = "Peanut Butter", UnitPrice = 7.25m, AvailableQuantity = 15},
            //    new CatalogProduct {Id = 4,Name = "Oreo", UnitPrice = 2.25m, AvailableQuantity = 12},
            //    new CatalogProduct {Id = 5,Name = "Cup Cake", UnitPrice = 12.00m, AvailableQuantity = 20},
            //    new CatalogProduct {Id = 6,Name = "Tea Cake", UnitPrice = 15.25m, AvailableQuantity = 20},
            //    new CatalogProduct {Id = 7,Name = "Fruit Cake", UnitPrice = 20.5m, AvailableQuantity = 8}
            //};


            var apiUrl = configuration["Identity:CatalogEndPoint"];

            httpClient.SetBearerToken(TokenHelper.Token);

            var getCustomerResponse = await httpClient.GetAsync(apiUrl);
            if (!getCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(getCustomerResponse.StatusCode.ToString());
                return new List<CatalogProduct>();
            }
            else
            {
                var content = await getCustomerResponse.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
                var catalogProducts = mapper.Map<IEnumerable<CatalogProduct>>(products);
                return catalogProducts;
            }
        }

        // Get Basket

        // Add to Basket
        public async Task<ShoppingCart> AddToBasket(string userId, CartItem item)
        {
            var apiUrl = $"{configuration["Identity:BasketEndPoint"]}/{userId}/AddItem";

            httpClient.SetBearerToken(TokenHelper.Token);

            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync(apiUrl, byteContent);

            var content = await response.Content.ReadAsStringAsync();
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(content);


            return cart;
        }

        // Remove from Basket

        public async Task<bool> RemoveBasket(string userId, CartItem item)
        {
            var apiUrl = $"{configuration["Identity:BasketEndPoint"]}/{userId}/RemoveItem";

            httpClient.SetBearerToken(TokenHelper.Token);

            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(apiUrl, byteContent);

            return result.IsSuccessStatusCode;
        }

        // Delete Basket
    }
}
