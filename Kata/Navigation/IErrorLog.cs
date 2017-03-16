using System.Collections.Generic;

namespace Kata.Navigation
{
    public interface IErrorLog
    {
        void LogError(string errorMsg);
        IEnumerable<string> ErrorLog { get; set; }
    }
}