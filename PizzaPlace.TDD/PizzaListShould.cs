using Bunit;
using PizzaPlace.Client.Pages;
using PizzaPlace.Shared;
using System.Collections.Generic;
using Xunit;

namespace PizzaPlace.TDD
{
    public class PizzaListShould : TestContext
    {
        [Fact]
        public void RenderCorrectlyWithListOfPizzas()
        {
            var cut = RenderComponent<PizzaList>(
                parameters =>
                parameters
                    .Add(pl => pl.Title, "PizzaList")
                    .Add(pl => pl.ButtonClass, "btn btn-success")
                    .Add(pl => pl.ButtonTitle, "Ok")
                    .Add(pl => pl.Items, new List<Pizza>()
                    {
                        new Pizza(1,"Test",0,Spiciness.None)
                    }));

            cut.MarkupMatches(
                @"<h1>PizzaList</h1>
                <div class=""row"">
                    <div class=""col"">Test</div>
                    <div class=""col text-right"">0,00</div>
                    <div class=""col""></div>
                    <div class=""col"">
                        <img height = ""32"" width=""32"" src=""images/none.png"" alt=""None"">
                    </div>
                    <div class=""col"">
                        <button class=""btn btn-success"" >Ok</button>
                    </div>
                </div>");
        }
    }
}
