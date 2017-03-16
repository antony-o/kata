using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Kata.Navigation;
using Kata.NavSystem;
using Kata.Planet;
using Xunit;

namespace Kata.Tests
{
    public class NavigationTests
    {

        private readonly IPlanet _fakePluto;
        private readonly IErrorLog _errorLog;

        public NavigationTests()
        {
            //Add fake errorlog 
            _errorLog = A.Fake<IErrorLog>();

            //Add fake Pluto
            _fakePluto = A.Fake<IPlanet>();
            A.CallTo(() => _fakePluto.MaxX).Returns(100);
            A.CallTo(() => _fakePluto.MaxY).Returns(100);

            //Add impassable large rock to planet
            var fakeLargeRock = A.Fake<ITerrainFeature>();
            A.CallTo(() => fakeLargeRock.Description).Returns("Large Rock");
            A.CallTo(() => fakeLargeRock.X).Returns(10);
            A.CallTo(() => fakeLargeRock.Y).Returns(10);

            A.CallTo(() => _fakePluto.TerrainFeatures).ReturnsLazily(() => new[]
            {
                fakeLargeRock
            });
        }

        [Theory]
        [InlineData(NavHeading.N, 0, 1)]
        [InlineData(NavHeading.E, 1, 0)]
        [InlineData(NavHeading.S, 0, 100)]
        [InlineData(NavHeading.W, 100, 0)]
        public void MoveF(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 0, 0);

            //Act
            navDrive.Execute("F");

            //Assert
            navDrive.CurrentHeading.Should().Be(initialHeading);
            navDrive.X.Should().Be(expectedX);
            navDrive.Y.Should().Be(expectedY);
        }

        [Theory]
        [InlineData(NavHeading.N, 100, 0)]
        [InlineData(NavHeading.E, 0, 100)]
        [InlineData(NavHeading.S, 100, 99)]
        [InlineData(NavHeading.W, 99, 100)]
        public void MoveF_100x100(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 100, 100);

            //Act
            navDrive.Execute("F");

            //Assert
            navDrive.CurrentHeading.Should().Be(initialHeading);
            navDrive.X.Should().Be(expectedX);
            navDrive.Y.Should().Be(expectedY);
        }


        [Theory]
        [InlineData(NavHeading.N, 0, 100)]
        [InlineData(NavHeading.E, 100, 0)]
        [InlineData(NavHeading.S, 0, 1)]
        [InlineData(NavHeading.W, 1, 0)]
        public void MoveB(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 0, 0);

            //Act
            navDrive.Execute("B");

            //Assert
            navDrive.CurrentHeading.Should().Be(initialHeading);
            navDrive.X.Should().Be(expectedX);
            navDrive.Y.Should().Be(expectedY);
        }

        [Theory]
        [InlineData(NavHeading.N, 100, 99)]
        [InlineData(NavHeading.E, 99, 100)]
        [InlineData(NavHeading.S, 100, 0)]
        [InlineData(NavHeading.W, 0, 100)]
        public void MoveB_100x100(NavHeading initialHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 100, 100);

            //Act
            navDrive.Execute("B");

            //Assert
            navDrive.CurrentHeading.Should().Be(initialHeading);
            navDrive.X.Should().Be(expectedX);
            navDrive.Y.Should().Be(expectedY);
        }



        [Theory]
        [InlineData(NavHeading.N, NavHeading.E)]
        [InlineData(NavHeading.E, NavHeading.S)]
        [InlineData(NavHeading.S, NavHeading.W)]
        [InlineData(NavHeading.W, NavHeading.N)]
        public void TurnR(NavHeading initialHeading, NavHeading expectedHeading)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 5, 5);

            //Act
            navDrive.Execute("R");

            //Assert
            navDrive.CurrentHeading.Should().Be(expectedHeading);
            navDrive.X.Should().Be(5);
            navDrive.Y.Should().Be(5);
        }

        [Theory]
        [InlineData(NavHeading.N, NavHeading.W)]
        [InlineData(NavHeading.W, NavHeading.S)]
        [InlineData(NavHeading.S, NavHeading.E)]
        [InlineData(NavHeading.E, NavHeading.N)]
        public void TurnL(NavHeading initialHeading, NavHeading expectedHeading)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 5, 5);

            //Act
            navDrive.Execute("L");

            //Assert
            navDrive.CurrentHeading.Should().Be(expectedHeading);
            navDrive.X.Should().Be(5);
            navDrive.Y.Should().Be(5);
        }

        [Theory]
        [InlineData(NavHeading.N, NavHeading.E, 2, 2)]
        [InlineData(NavHeading.S, NavHeading.W, 99, 99)]
        public void MoveFFRFF(NavHeading initialHeading, NavHeading expectedHeading, int expectedX, int expectedY)
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, initialHeading, 0, 0);

            //Act
            navDrive.Execute("FFRFF");

            //Assert
            navDrive.CurrentHeading.Should().Be(expectedHeading);
            navDrive.X.Should().Be(expectedX);
            navDrive.Y.Should().Be(expectedY);
        }

        [Fact]
        public void DetectObstacle()
        {
            //Arrange
            var navDrive = _landOnPlanet(_fakePluto, NavHeading.N, 9, 9);
            string expectedErrorMsg = "";

            A.CallTo(() => _errorLog.LogError(A<string>._))
                .Invokes((string errorMsg) =>
                {
                    expectedErrorMsg = errorMsg;
                });


            //Act
            navDrive.Execute("FRFF");

            //Assert
            navDrive.CurrentHeading.Should().Be(NavHeading.E);
            navDrive.X.Should().Be(9);
            navDrive.Y.Should().Be(10);
            expectedErrorMsg.Should().Be("Nav Error: Large Rock blocked route at coords (10,10).");
        }


        #region TestHelper


        private NavigationDrive _landOnPlanet(IPlanet planet, NavHeading initialHeading, int initialX, int initialY)
        {
            //Create nav drive sequence
            var navDriveSequence = new List<INavSystemCommand>()
            {
                new CoordsCheck(),
                new TerrainCheck(),
                new MoveToTargetCoords()
           };


            //Create nav command list
            var navCommandList = new List<INavCommand>()
            {
                new MoveF(navDriveSequence),
                new MoveB(navDriveSequence),
                new TurnL(),
                new TurnR()
            };


            var navDrive = new NavigationDrive(planet, navCommandList, _errorLog, initialHeading, initialX, initialY);

            return navDrive;
        }

        #endregion
    }
}
