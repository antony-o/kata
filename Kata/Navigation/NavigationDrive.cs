using System.Collections.Generic;
using System.Linq;
using Kata.Planet;

namespace Kata.Navigation
{
    public interface INavigationDrive
    {
        IPlanet CurrentPlanet { get; set; }
        NavHeading CurrentHeading { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void Execute(string commands);
    }

    public class NavigationDrive : INavigationDrive
    {
        public IPlanet CurrentPlanet { get; set; }
        public IList<INavCommand> NavCommandList { get; set; }
        public NavHeading CurrentHeading { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public NavigationDrive(IPlanet planet, IList<INavCommand> navCommandList, NavHeading initialHeading, int initialX, int initialY)
        {
            CurrentPlanet = planet;
            NavCommandList = navCommandList;
            CurrentHeading = initialHeading;
            X = initialX;
            Y = initialY;
        }

        public void Execute(string navCommands)
        {
            char[] arrayCmdLetters = navCommands.ToUpper().ToArray();

            foreach (var cmdLetter in arrayCmdLetters)
            {
                var navCommand = NavCommandList.FirstOrDefault(cmd => cmd.CommandLetter == cmdLetter);

                if (navCommand != null)
                {
                    navCommand.Execute(this);
                }
                else
                {
                    //TODO: log error
                }
            }
        }
    }
}
