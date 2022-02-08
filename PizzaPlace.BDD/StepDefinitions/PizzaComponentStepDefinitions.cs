using Bunit;
using PizzaPlace.Client.Pages;
using PizzaPlace.Shared;

namespace PizzaPlace.BDD.StepDefinitions
{
    [Binding]
    public class PizzaComponentStepDefinitions : TestContext
    {
        private readonly IRenderedComponent<PizzaList> PizzaListComponent;
        IMenuService MenuService { get; set; } = default!;
        IEnumerable<Pizza> Pizzas { get; set; } = default!;

        public PizzaComponentStepDefinitions()
        {
            PizzaListComponent = RenderComponent<PizzaList>();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            MenuService = new HardCodedMenuService();
        }


        [Given(@"Une liste de pizzas")]
        public async void GivenUneListeDePizzas()
        {
            var menu = await MenuService.GetMenu();
            Pizzas = menu.Pizzas;
            Pizzas.Should().NotBeEmpty();
        }

        [When(@"Ouvrir le page de pizzas")]
        public void WhenOuvrirLePageDePizzas()
        {
            PizzaListComponent.SetParametersAndRender(parameters =>
                parameters
                    .Add(param => param.ButtonClass, "btn btn-success")
                    .Add(param => param.ButtonTitle, "demander")
                    .Add(param => param.Items, this.Pizzas)
                    .Add(param => param.Title, "Pizza liste")
            );
        }

        [Then(@"Montrer la liste")]
        public void ThenMontrerLaListe()
        {
            PizzaListComponent
                .MarkupMatches(@"
                <h1>Pizza liste</h1>
                    <div class=""row"">
                      <div class=""col"">Pepperoni</div>
                      <div class=""col text-right"">8.99</div>
                      <div class=""col""></div>
                      <div class=""col"">
                        <img height=""32"" width=""32"" src=""images/spicy.png"" alt=""Spicy"">
                      </div>
                      <div class=""col"">
                        <button class=""btn btn-success"">demander</button>
                      </div>
                    </div>
                    <div class=""row"">
                      <div class=""col"">Margarita</div>
                      <div class=""col text-right"">7.99</div>
                      <div class=""col""></div>
                      <div class=""col"">
                        <img height=""32"" width=""32"" src=""images/none.png"" alt=""None"">
                      </div>
                      <div class=""col"">
                        <button class=""btn btn-success"">demander</button>
                      </div>
                    </div>
                    <div class=""row"">
                      <div class=""col"">Diabolo</div>
                      <div class=""col text-right"">9.99</div>
                      <div class=""col""></div>
                      <div class=""col"">
                        <img height=""32"" width=""32"" src=""images/hot.png"" alt=""Hot"">
                      </div>
                      <div class=""col"">
                        <button class=""btn btn-success"">demander</button>
                      </div>
                    </div>");
        }

        [Then(@"Demander une pizza")]
        public void ThenDemanderUnePizza()
        {
            var buttonsDemande = PizzaListComponent.FindAll("button");
            
            buttonsDemande.Should().NotBeEmpty().And.HaveCount(Pizzas.Count());

            buttonsDemande
                .ToList()
                .ForEach(pizza => pizza.Click());
        }

    }
}
