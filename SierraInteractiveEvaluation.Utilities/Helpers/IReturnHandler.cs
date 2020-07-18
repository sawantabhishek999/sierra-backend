using SierraInteractiveEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Utilities.Helpers
{
    interface IReturnHandler<T> where T : class
    {
        ReturnObject<T> GetReturnObject(bool isError, Error errorObject, string message, T data);
    }
}
