using FluentAssertions;
using Kata.Navigation;
using Xunit;

namespace Kata.Tests
{
    public class NavigationTests
    {
        [Fact]
        public void MoveF()
        {
            //Arrange
            var navigation = new NavigationDrive(NavHeading.N, 0, 0);

            //Act
            navigation.Move(new MoveF());

            //Assert
            navigation.CurrentHeading.Should().Be(NavHeading.N);
            navigation.X.Should().Be(0);
            navigation.Y.Should().Be(1);
        }

        [Fact]
        public void MoveB()
        {
            //Arrange
            var navigation = new NavigationDrive(NavHeading.N, 0, 0);

            //Act
            navigation.Move(new MoveB());

            //Assert
            navigation.CurrentHeading.Should().Be(NavHeading.N);
            navigation.X.Should().Be(0);
            navigation.Y.Should().Be(-1);
        }

        [Theory]
        [InlineData(NavHeading.N, NavHeading.E)]
        [InlineData(NavHeading.E, NavHeading.S)]
        [InlineData(NavHeading.S, NavHeading.W)]
        [InlineData(NavHeading.W, NavHeading.N)]
        public void TurnR(NavHeading initialHeading, NavHeading expectedHeading)
        {
            //Arrange
            var navigation = new NavigationDrive(initialHeading, 5, 5);

            //Act
            navigation.Move(new TurnR());

            //Assert
            navigation.CurrentHeading.Should().Be(expectedHeading);
            navigation.X.Should().Be(5);
            navigation.Y.Should().Be(5);
        }
    }
}
