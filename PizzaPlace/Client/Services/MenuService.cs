using PizzaPlace.Shared;
using System.Net.Http.Json;

namespace PizzaPlace.Client.Services
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;

        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<Menu> GetMenu()
        {
            var pizzas = await _httpClient.GetFromJsonAsync<Pizza[]>("/pizzas");
            return new Menu { Pizzas = pizzas!.ToList() };
        }
    }
}
