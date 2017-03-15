namespace Kata.Navigation
{
    public class MoveB: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navigationDrive)
        {
            switch (navigationDrive.CurrentHeading)
            {
                case NavHeading.N:
                    navigationDrive.Y--;
                    break;

                case NavHeading.E:
                    navigationDrive.X--;
                    break;

                case NavHeading.S:
                    navigationDrive.Y++;
                    break;

                case NavHeading.W:
                    navigationDrive.X++;
                    break;

            }

            return navigationDrive;
        }
    }
}
