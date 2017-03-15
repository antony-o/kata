using System;

namespace Kata.Navigation
{
    public interface INavCommand
    {
        Char CommandLetter { get; }
        INavigationDrive Execute(INavigationDrive navDrive);
    }
}
