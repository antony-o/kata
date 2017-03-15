using System;

namespace Kata.Navigation
{
    public class TurnR: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            int newHeading = ((int)navDrive.CurrentHeading) + 1;

            if (newHeading > 4)
            {
                newHeading = 1;
            }

            navDrive.CurrentHeading = (NavHeading)newHeading;

            return navDrive;
        }
    }
}
