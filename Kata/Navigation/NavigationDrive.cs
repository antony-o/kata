namespace Kata.Navigation
{
    public interface INavigationDrive
    {
        NavHeading CurrentHeading { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void Move(INavCommand navcommand);
    }

    public class NavigationDrive : INavigationDrive
    {
        public NavHeading CurrentHeading { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public NavigationDrive(NavHeading initialHeading, int initialX, int initialY)
        {
            CurrentHeading = initialHeading;
            X = initialX;
            Y = initialY;
        }

        public void Move(INavCommand navCommand)
        {
            navCommand.Execute(this);
        }
    }
}
