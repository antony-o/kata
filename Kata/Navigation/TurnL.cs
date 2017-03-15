using System;

namespace Kata.Navigation
{
    public class TurnL: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navigationDrive)
        {
            int newHeading = ((int)navigationDrive.CurrentHeading) - 1;

            if (newHeading < 1)
            {
                newHeading = 4;
            }

            navigationDrive.CurrentHeading = (NavHeading)newHeading;

            return navigationDrive;
        }
    }
}
