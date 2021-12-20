namespace PizzaPlace.Shared
{
    public class Menu
    {
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public void AddPizza(Pizza pizza) => Pizzas.Add(pizza);
        public Pizza? GetPizza(int id) => this.Pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }
}
