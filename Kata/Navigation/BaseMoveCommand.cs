
namespace Kata.Navigation
{
    public abstract class BaseMoveCommand
    {
        public void WrapTargetCoords(INavigationDrive navDrive) 
        {
            //Check Coord Boundaries
            var planet = navDrive.CurrentPlanet;

            if (navDrive.TargetX > planet.MaxX) navDrive.TargetX = 0;
            if (navDrive.TargetX < 0) navDrive.TargetX = planet.MaxX;
            if (navDrive.TargetY > planet.MaxY) navDrive.TargetY = 0;
            if (navDrive.TargetY < 0) navDrive.TargetY = planet.MaxY;
        }

        public void CheckForTerrainObstacles(INavigationDrive navDrive)
        {
            var planet = navDrive.CurrentPlanet;

            foreach (var terrainObstacle in planet.TerrainObstacles)
            {
                if (terrainObstacle.X == navDrive.TargetX && terrainObstacle.Y == navDrive.TargetY)
                {
                    navDrive.Logger.LogError($"Nav Error: {terrainObstacle.Description} blocked route at coords ({navDrive.TargetX},{navDrive.TargetY}).");
                    navDrive.NavError = true;
                }
            }
        }

        public void MoveToTargetCoords(INavigationDrive navDrive)
        {
            if (navDrive.NavError)
            {
                return;
            }

            navDrive.X = navDrive.TargetX;
            navDrive.Y = navDrive.TargetY;
        }

    }
}
