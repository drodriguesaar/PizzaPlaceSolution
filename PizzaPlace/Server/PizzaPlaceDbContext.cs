using Microsoft.EntityFrameworkCore;
using PizzaPlace.Shared;

namespace PizzaPlace.Server
{
    public class PizzaPlaceDbContext : DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options)
            : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            PizzaModelBuilder(modelBuilder);
            OrderModelBuilder(modelBuilder);
            CustomerModelBuilder(modelBuilder);
        }

        private static void CustomerModelBuilder(ModelBuilder modelBuilder)
        {
            var customerEntity = modelBuilder.Entity<Customer>();

            customerEntity
                .HasKey(customer => customer.Id);

            customerEntity
                .Property(customer => customer.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            customerEntity
                .Property(customer => customer.Street)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            customerEntity
                .Property(customer => customer.City)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }

        private static void OrderModelBuilder(ModelBuilder modelBuilder)
        {
            var ordersEntity = modelBuilder.Entity<Order>();

            ordersEntity
                .HasKey(order => order.Id);

            ordersEntity
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders);

            ordersEntity
                .HasMany(order => order.Pizzas)
                .WithMany(pizza => pizza.Orders);
        }

        private static void PizzaModelBuilder(ModelBuilder modelBuilder)
        {
            var pizzaEntity = modelBuilder.Entity<Pizza>();

            pizzaEntity
                .HasKey(pizza => pizza.Id);

            pizzaEntity
                .Property(pizza => pizza.Name)
                .HasColumnType("varchar")
                .HasMaxLength(80);

            pizzaEntity
                .Property(pizza => pizza.Price)
                .HasColumnType("money");

            pizzaEntity
                .Property(pizza => pizza.Spiciness)
                .HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
