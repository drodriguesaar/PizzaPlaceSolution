namespace PizzaPlace.Shared
{
    public class ConsoleOrderService : IOrderService
    {
        public ValueTask<Order> GetOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> PlaceOrder(ShoppingBasket basket)
        {
            Console.WriteLine($"Placing order for {basket.Customer.Name}");
            return new ValueTask<Order>();
        }
    }
}
