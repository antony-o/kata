using Kata.Planet;

namespace Kata.Navigation
{
    public interface INavigationDrive
    {
        IPlanet CurrentPlanet { get; set; }
        NavHeading CurrentHeading { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void Move(INavCommand navcommand);
    }

    public class NavigationDrive : INavigationDrive
    {
        public IPlanet CurrentPlanet { get; set; }
        public NavHeading CurrentHeading { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public NavigationDrive(IPlanet planet, NavHeading initialHeading, int initialX, int initialY)
        {
            CurrentPlanet = planet;
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
