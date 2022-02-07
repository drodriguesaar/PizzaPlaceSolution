using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Shared
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Please provide a street with a houser number")]
        public string Street { get; set; } = default!;
        [Required(ErrorMessage = "Please provide a city")]
        public string City { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
