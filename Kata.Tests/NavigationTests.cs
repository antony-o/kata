using FluentAssertions;
using Kata.Navigation;
using Xunit;

namespace Kata.Tests
{
    public class NavigationTests
    {
        [Theory]
        [InlineData(NavHeading.N, 0, 1)]
        [InlineData(NavHeading.E, 1, 0)]
        [InlineData(NavHeading.S, 0, -1)]
        [InlineData(NavHeading.W, -1, 0)]
        public void MoveF(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navigation = new NavigationDrive(initialHeading, 0, 0);

            //Act
            navigation.Move(new MoveF());

            //Assert
            navigation.CurrentHeading.Should().Be(initialHeading);
            navigation.X.Should().Be(expectedX);
            navigation.Y.Should().Be(expectedY);
        }

        [Theory]
        [InlineData(NavHeading.N, 0, -1)]
        [InlineData(NavHeading.E, -1, 0)]
        [InlineData(NavHeading.S, 0, 1)]
        [InlineData(NavHeading.W, 1, 0)]
        public void MoveB(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navigation = new NavigationDrive(initialHeading, 0, 0);

            //Act
            navigation.Move(new MoveB());

            //Assert
            navigation.CurrentHeading.Should().Be(initialHeading);
            navigation.X.Should().Be(expectedX);
            navigation.Y.Should().Be(expectedY);
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

        [Theory]
        [InlineData(NavHeading.N, NavHeading.W)]
        [InlineData(NavHeading.W, NavHeading.S)]
        [InlineData(NavHeading.S, NavHeading.E)]
        [InlineData(NavHeading.E, NavHeading.N)]
        public void TurnL(NavHeading initialHeading, NavHeading expectedHeading)
        {
            //Arrange
            var navigation = new NavigationDrive(initialHeading, 5, 5);

            //Act
            navigation.Move(new TurnL());

            //Assert
            navigation.CurrentHeading.Should().Be(expectedHeading);
            navigation.X.Should().Be(5);
            navigation.Y.Should().Be(5);
        }

    }
}
