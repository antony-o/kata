using System.Collections.Generic;

namespace Kata.Navigation
{
    public class MoveF : INavCommand
    {
        private readonly IEnumerable<INavSystemCommand> _driveCmdSequence;

        public MoveF(IEnumerable<INavSystemCommand> driveCmdSequence)
        {
            _driveCmdSequence = driveCmdSequence;
        }
        public char CommandLetter => 'F';

        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            navDrive.TargetX = navDrive.X;
            navDrive.TargetY = navDrive.Y;

            switch (navDrive.CurrentHeading)
            {
                case NavHeading.N:
                    navDrive.TargetY =  navDrive.Y + 1;
                    break;

                case NavHeading.E:
                    navDrive.TargetX = navDrive.X + 1;
                    break;

                case NavHeading.S:
                    navDrive.TargetY = navDrive.Y - 1;
                    break;

                case NavHeading.W:
                    navDrive.TargetX = navDrive.X - 1;
                    break;
            }

            //Execute Drive Command Sequence
            foreach (var systemCmd in _driveCmdSequence)
            {
                systemCmd.Execute(navDrive);
            }

            return navDrive;
        }
    }
}
