using System;

namespace Kata.Navigation
{
    public class TurnR: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navigationDrive)
        {
            int newHeading = ((int)navigationDrive.CurrentHeading) + 1;

            if (newHeading > 4)
            {
                newHeading = 1;
            }

            navigationDrive.CurrentHeading = (NavHeading)newHeading;

            return navigationDrive;
        }
    }
}
