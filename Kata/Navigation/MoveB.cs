using System.Collections.Generic;

namespace Kata.Navigation
{
    public class MoveB: INavCommand
    {
        private readonly IEnumerable<INavSystemCommand> _driveCmdSequence;

        public MoveB(IEnumerable<INavSystemCommand> driveCmdSequence)
        {
            _driveCmdSequence = driveCmdSequence;
        }
        public char CommandLetter => 'B';

        public INavigationDrive Execute(INavigationDrive navDrive)
        {
            switch (navDrive.CurrentHeading)
            {
                case NavHeading.N:
                    navDrive.TargetY = navDrive.Y - 1;
                    break;

                case NavHeading.E:
                    navDrive.TargetX = navDrive.X - 1;
                    break;

                case NavHeading.S:
                    navDrive.TargetY = navDrive.Y + 1;
                    break;

                case NavHeading.W:
                    navDrive.TargetX = navDrive.X + 1;
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
