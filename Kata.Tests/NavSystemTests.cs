using FakeItEasy;
using FluentAssertions;
using Kata.Navigation;
using Kata.NavSystem;
using Kata.Planet;
using Xunit;

namespace Kata.Tests
{
    public class NavSystemTests
    {

        private readonly IPlanet _fakePluto;
        private readonly IErrorLog _logger;
        private string _expectedErrorMsg = "";

        public NavSystemTests()
        {
            //Add fake errorlog 
            _logger = A.Fake<IErrorLog>();
            A.CallTo(() => _logger.LogError(A<string>._))
                .Invokes((string errorMsg) =>
                {
                    _expectedErrorMsg = errorMsg;
                });

            //Add fake Pluto
            _fakePluto = A.Fake<IPlanet>();
            A.CallTo(() => _fakePluto.MaxX).Returns(100);
            A.CallTo(() => _fakePluto.MaxY).Returns(100);

            A.CallTo(() => _fakePluto.TerrainFeatures)
                .ReturnsLazily(() => new[]
                {
                    new FakeAlien()
                });
        }

        [Fact]
        public void CoordsCheck()
        {
            //Arrange
            var navDrive = A.Fake<INavigationDrive>();
            navDrive.TargetX = -1;
            navDrive.CurrentPlanet = _fakePluto;

            //Act
            var coordsCheck = new CoordsCheck();
            coordsCheck.Execute(navDrive);

            //Assert
            navDrive.TargetX.Should().Be(100);
        }

        [Fact]
        public void TerrainCheck()
        {
            //Arrange
            var navDrive = A.Fake<INavigationDrive>();
            navDrive.Logger = _logger;
            navDrive.TargetX = 5;
            navDrive.TargetY = 5;
            navDrive.CurrentPlanet = _fakePluto;

            //Act
            var terrainCheck = new TerrainCheck();
            terrainCheck.Execute(navDrive);

            //Assert
            navDrive.NavError.Should().BeTrue();
            _expectedErrorMsg.Should().Be("Nav Error: Alien blocked route at coords (5,5).");
        }

        [Fact]
        public void MoveToCoords()
        {
            //Arrange
            var navDrive = A.Fake<INavigationDrive>();
            navDrive.Y = 50;
            navDrive.TargetY = 49;
            navDrive.CurrentPlanet = _fakePluto;

            //Act
            var moveToTargetCoords = new MoveToTargetCoords();
            moveToTargetCoords.Execute(navDrive);

            //Assert
            navDrive.Y.Should().Be(49);
        }

    }

    public class FakeAlien : ITerrainFeature
    {
        public string Description { get; set; } = "Alien";
        public int X { get; set; } = 5;
        public int Y { get; set; } = 5;
    }
}
