using Microsoft.AspNetCore.Components;

using FinalBoss.Models.Colors;

namespace FinalBoss.Views.Bases
{
    public partial class LabelBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public Color Color { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            InvokeAsync(StateHasChanged);
        }

        public void SetColor(Color color) =>
            this.Color = color;
    }
}