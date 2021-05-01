using Microsoft.AspNetCore.Components;

using FinalBoss.Models.ContainerComponents;

namespace FinalBoss.Views.Components.ContainComponents
{
    public partial class ContainerComponent : ComponentBase
    {
        [Parameter]
        public ComponentState State { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string Error { get; set; }
    }
}