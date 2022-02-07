using PizzaPlace.Shared;
using System.Net.Http.Json;

namespace PizzaPlace.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<Order> GetOrder(int Id)
        {
            var order = await _httpClient.GetFromJsonAsync<Order>($"/orders/{Id}");
            return order;
        }

        public async ValueTask<Order> PlaceOrder(ShoppingBasket basket)
        {
            var order = await _httpClient.PostAsJsonAsync("/order", basket);

            order.EnsureSuccessStatusCode();

            var orderId = await order.Content.ReadAsStringAsync();

            int.TryParse(orderId, out int Id);

            var newOrder = await GetOrder(Id);

            return newOrder;
        }
    }
}
