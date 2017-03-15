
namespace Kata.Navigation
{
    public abstract class BaseMoveCommand
    {
        public void WrapCoords(INavigationDrive navDrive) 
        {
            //Check Coord Boundaries
            var planet = navDrive.CurrentPlanet;

            if (navDrive.X > planet.MaxX) navDrive.X = 0;
            if (navDrive.X < 0) navDrive.X = planet.MaxX;
            if (navDrive.Y > planet.MaxY) navDrive.Y = 0;
            if (navDrive.Y < 0) navDrive.Y = planet.MaxY;
        }
    }
}
