using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Utilities
{
    public interface ILogger
    {
        void Error(string message);
        void Error(Exception exception);
        void Information(string message);
    }
}
