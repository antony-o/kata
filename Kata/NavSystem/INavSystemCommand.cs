using System;

namespace Kata.Navigation
{
    public interface INavSystemCommand
    {
        string SystemName { get; }
        INavigationDrive Execute(INavigationDrive navDrive);
    }
}
