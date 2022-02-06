using PizzaPlace.Shared;

namespace PizzaPlace.Server
{
    public class PizzaBusiness : IPizzaBusiness
    {
        PizzaPlaceDbContext _context;

        public PizzaBusiness(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Pizza> Create(Pizza pizza)
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public IQueryable<Pizza> GetAll()
        {
            return _context
                    .Pizzas
                        .AsParallel()
                        .AsOrdered()
                        .AsQueryable();
        }
    }

    public interface IPizzaBusiness
    {
        ValueTask<Pizza> Create(Pizza pizza);
        IQueryable<Pizza> GetAll();
    }
}
