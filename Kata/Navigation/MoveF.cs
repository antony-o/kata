namespace Kata.Navigation
{
    public class MoveF: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navigationDrive)
        {
            navigationDrive.Y++;

            return navigationDrive;
        }
    }
}
