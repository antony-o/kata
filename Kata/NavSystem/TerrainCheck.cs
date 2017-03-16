using Kata.Navigation;

namespace Kata.NavSystem
{
    public class TerrainCheck : INavSystemCommand
    {
        public string SystemName => nameof(TerrainCheck);

        public INavigationDrive Execute(INavigationDrive navDrive) 
        {
            var planet = navDrive.CurrentPlanet;

            foreach (var terrainFeature in planet.TerrainFeatures)
            {
                if (terrainFeature.X == navDrive.TargetX && terrainFeature.Y == navDrive.TargetY)
                {
                    navDrive.Logger.LogError($"Nav Error: {terrainFeature.Description} blocked route at coords ({navDrive.TargetX},{navDrive.TargetY}).");
                    navDrive.NavError = true;
                }
            }

            return navDrive;
        }
    }
}