using Microsoft.AspNetCore.Components;

using FinalBoss.Models.ContainerComponents;
using FinalBoss.Views.Bases;

namespace FinalBoss.Views.Components
{
    public partial class ExampleComponent : ComponentBase
    {
        public ComponentState State { get; set; }

        public TextBoxBase ExampleTextBox { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}