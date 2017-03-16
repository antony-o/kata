using Kata.Navigation;

namespace Kata.NavSystem
{
    public class MoveToTargetCoords : INavSystemCommand
    {
        public string SystemName => nameof(MoveToTargetCoords);

        public INavigationDrive Execute(INavigationDrive navDrive) 
        {
            if (navDrive.NavError)
            {
                return navDrive;
            }

            navDrive.X = navDrive.TargetX;
            navDrive.Y = navDrive.TargetY;

            return navDrive;
        }
    }
}