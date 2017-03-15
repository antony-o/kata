﻿namespace Kata.Navigation
{
    public class MoveF: BaseMoveCommand, INavCommand
    {
        public char CommandLetter => 'F';

        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            switch (navDrive.CurrentHeading)
            {
                case NavHeading.N:
                    navDrive.Y++;
                    break;

                case NavHeading.E:
                    navDrive.X++;
                    break;

                case NavHeading.S:
                    navDrive.Y--;
                    break;

                case NavHeading.W:
                    navDrive.X--;
                    break;
            }

            WrapCoords(navDrive);

            return navDrive;
        }
    }
}
