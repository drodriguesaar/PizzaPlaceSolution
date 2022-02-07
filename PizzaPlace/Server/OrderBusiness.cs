using Microsoft.EntityFrameworkCore;
using PizzaPlace.Shared;

namespace PizzaPlace.Server
{
    public class OrderBusiness : IOrderService
    {
        PizzaPlaceDbContext _context;

        public OrderBusiness(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        public ValueTask<Order> GetOrder(int Id)
        {
            var order = _context
                            .Orders
                            .Include(order => order.Pizzas)
                            .Include(order => order.Customer)
                            .Select(o => new Order
                            {
                                Id = o.Id,
                                Customer =
                                    new Customer
                                    {
                                        Id = o.Customer.Id,
                                        City = o.Customer.City,
                                        Name = o.Customer.Name,
                                        Street = o.Customer.Street,
                                    },
                                Pizzas = o.Pizzas,
                            })
                            .SingleOrDefault(order => order.Id == Id);



            return new ValueTask<Order>(order!);
        }

        public async ValueTask<Order> PlaceOrder(ShoppingBasket basket)
        {
            Order order = new Order();
            order.Customer = basket.Customer;
            order.Pizzas = new List<Pizza>();
            foreach (int pizzaId in basket.Orders)
            {
                var pizza = _context.Pizzas.Single(p => p.Id == pizzaId);
                order.Pizzas.Add(pizza);
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
