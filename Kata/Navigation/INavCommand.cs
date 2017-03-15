using System;

namespace Kata.Navigation
{
    public interface INavCommand
    {
        INavigationDrive Execute(INavigationDrive navDrive);
    }
}
