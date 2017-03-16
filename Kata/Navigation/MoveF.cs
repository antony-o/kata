using System.Security.Cryptography.X509Certificates;

namespace Kata.Navigation
{
    public class MoveF: BaseMoveCommand, INavCommand
    {
        public char CommandLetter => 'F';

        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            navDrive.TargetX = navDrive.X;
            navDrive.TargetY = navDrive.Y;

            switch (navDrive.CurrentHeading)
            {
                case NavHeading.N:
                    navDrive.TargetY =  navDrive.Y + 1;
                    break;

                case NavHeading.E:
                    navDrive.TargetX = navDrive.X + 1;
                    break;

                case NavHeading.S:
                    navDrive.TargetY = navDrive.Y - 1;
                    break;

                case NavHeading.W:
                    navDrive.TargetX = navDrive.X - 1;
                    break;
            }

            //Drive Command Sequence
            WrapTargetCoords(navDrive);
            CheckForTerrainObstacles(navDrive);
            MoveToTargetCoords(navDrive);

            return navDrive;
        }
    }
}
