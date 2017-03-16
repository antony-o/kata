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
        int TargetX { get; set; }
        int TargetY { get; set; }
        IErrorLog Logger { get; set; }
        bool NavError { get; set; }

        void Execute(string commands);
    }

    public class NavigationDrive : INavigationDrive
    {
        public IPlanet CurrentPlanet { get; set; }
        public IList<INavCommand> NavCommandList { get; set; }
        public NavHeading CurrentHeading { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public IErrorLog Logger { get; set; }
        public bool NavError { get; set; }

        public NavigationDrive(IPlanet planet, IList<INavCommand> navCommandList, IErrorLog errorLogger, NavHeading initialHeading, int initialX, int initialY)
        {
            CurrentPlanet = planet;
            NavCommandList = navCommandList;
            Logger = errorLogger;
            CurrentHeading = initialHeading;
            X = initialX;
            Y = initialY;
            TargetX = X;
            TargetY = Y;
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
                    if (NavError)
                    {
                        break;
                    }
                }
            }
        }
    }
}
