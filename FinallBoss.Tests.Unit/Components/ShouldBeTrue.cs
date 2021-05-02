using Xunit;

namespace FinallBoss.Tests.Unit.Components
{
    public class ShouldBeTrue
    {
        [Fact]
        public void ShouldBeTrueTest() => Assert.True(condition: true);
    }
}