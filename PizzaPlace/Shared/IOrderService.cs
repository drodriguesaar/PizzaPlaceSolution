namespace PizzaPlace.Shared
{
    public interface IOrderService
    {
        ValueTask<Order> PlaceOrder(ShoppingBasket basket);
        ValueTask<Order> GetOrder(int Id);
    }
}
