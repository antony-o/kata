namespace Kata.Navigation
{
    public class MoveB: INavCommand
    {
        public INavigationDrive Execute(INavigationDrive navigationDrive)
        {
            navigationDrive.Y--;

            return navigationDrive;
        }
    }
}
