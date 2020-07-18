using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models
{
    public class ReturnObject<T> where T : class
    {
        public bool IsError { get; set; }
        public Error Error { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
