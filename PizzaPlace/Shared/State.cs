namespace PizzaPlace.Shared
{
    public class State
    {
        public Menu Menu { get; set; } = new Menu();
        public ShoppingBasket Basket { get; set; } = new ShoppingBasket();
        public UI UI { get; set; } = new UI();

        public decimal TotalPrice => Basket.Orders.Sum(id => Menu.GetPizza(id)!.Price);
    }
}
