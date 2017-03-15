using System;

namespace Kata.Navigation
{
    public class TurnL: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            int newHeading = ((int)navDrive.CurrentHeading) - 1;

            if (newHeading < 1)
            {
                newHeading = 4;
            }

            navDrive.CurrentHeading = (NavHeading)newHeading;

            return navDrive;
        }
    }
}
