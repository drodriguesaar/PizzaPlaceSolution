using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace PizzaPlace.Client.Pages
{
    public class InputWatcher : ComponentBase
    {
        private EditContext editContext = default!;

        [CascadingParameter]
        public EditContext EditContext
        {
            get => editContext;
            set
            {
                this.editContext = value;
                EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            }
        }

        private async void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName);
        }

        [Parameter]
        public EventCallback<string> FieldChanged { get; set; }

        public bool Validate() => EditContext?.Validate() ?? false;
    }
}
