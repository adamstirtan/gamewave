using FluentAssertions;

using Xunit;

using FinalBoss.Models.ContainerComponents;
using FinalBoss.Views.Components;

namespace FinallBoss.Tests.Unit.Components
{
    public partial class ExampleComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            var initialExampleComponent = new ExampleComponent();

            initialExampleComponent.ExampleTextBox.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            ComponentState expectedState = ComponentState.Content;

            this.renderedExampleComponent =
                RenderComponent<ExampleComponent>();

            this.renderedExampleComponent.Instance.State
                .Should().BeEquivalentTo(expectedState);

            this.renderedExampleComponent.Instance.ExampleTextBox
                .Should().NotBeNull();

            this.renderedExampleComponent.Instance.ExampleTextBox.Placeholder
                .Should().BeEquivalentTo("Example");
        }
    }
}