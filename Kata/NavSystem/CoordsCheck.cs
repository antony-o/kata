using Kata.Navigation;

namespace Kata.NavSystem
{
    public class CoordsCheck: INavSystemCommand
    {
        public string SystemName => nameof(CoordsCheck);

        public INavigationDrive Execute(INavigationDrive navDrive) 
        {
            //Check Coord Boundaries
            var planet = navDrive.CurrentPlanet;

            if (navDrive.TargetX > planet.MaxX) navDrive.TargetX = 0;
            if (navDrive.TargetX < 0) navDrive.TargetX = planet.MaxX;
            if (navDrive.TargetY > planet.MaxY) navDrive.TargetY = 0;
            if (navDrive.TargetY < 0) navDrive.TargetY = planet.MaxY;

            return navDrive;
        }
    }
}