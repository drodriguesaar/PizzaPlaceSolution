using Bunit;
using PizzaPlace.Client.Pages;
using PizzaPlace.Shared;

namespace PizzaPlace.BDD.StepDefinitions
{
    [Binding]
    public class OrderComponentStepDefinitions : TestContext
    {
        private readonly IRenderedComponent<CustomerEntry> CustomerEntryComponent;

        IOrderService OrderService { get; set; } = default!;

        public OrderComponentStepDefinitions()
        {
            CustomerEntryComponent = RenderComponent<CustomerEntry>
            (
                parameters => parameters.Add(param => param.Customer, new Customer())
            );
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            OrderService = new ConsoleOrderService();
        }

        [Given(@"Une demande")]
        public void GivenUneDemande()
        {
            CustomerEntryComponent.SetParametersAndRender(
                parameters =>
                parameters.Add(param => param.ButtonClass, "btn btn-success")
                          .Add(param => param.ButtonTitle, "Demander")
                          .Add(param => param.Title, "Demande Pizza")
            );
        }

        [When(@"Ouvrir page de demande")]
        public void WhenOuvrirPageDeDemande()
        {
            CustomerEntryComponent
               .FindAll("input.form-control col-6").ToList()
               .ForEach(input => input.Change(" "));
        }

        [Then(@"Placer une demande")]
        public void ThenPlacerUneDemande()
        {
            CustomerEntryComponent
               .Find("form")
               .TriggerEvent("onsubmit", new EventArgs());
        }

        [Then(@"Montrer erreurs")]
        public void ThenMontrerErreurs()
        {
            CustomerEntryComponent.FindAll("div.validation-message")
                .Should()
                .NotBeEmpty();
        }
    }
}
