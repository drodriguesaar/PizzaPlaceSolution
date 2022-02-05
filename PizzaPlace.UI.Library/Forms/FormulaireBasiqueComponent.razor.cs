using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.UI.Library.Forms
{
    public partial class FormulaireBasiqueComponent
    {
        [Parameter]
        public RenderFragment Contenu { get; set; } = default!;

        [Parameter]
        public EventCallback OnOkEvent { get; set; }

        [Parameter]
        public EventCallback OnCancelEvent { get; set; }
    }
}
