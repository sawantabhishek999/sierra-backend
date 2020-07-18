using SierraInteractiveEvaluation.Models;
using SierraInteractiveEvaluation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Utilities.Helpers
{
    public class ReturnHandler<T> where T : class
    {
        public static ReturnObject<T> GetReturnObject(bool isError, Error errorObject, string message, T data)
        {
            return new ReturnObject<T>
            {
                IsError = isError,
                Error = errorObject,
                Message = message,
                Data = data,
            };
        }
    }
}
