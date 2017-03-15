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
    }
}
