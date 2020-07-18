using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models
{
    public class Enums
    {
        public enum LeadTypeEnum
        {
            BUYER = 1,
            SELLER = 2,
            BOTH = 3
        }

        public enum ErrorTypeKeys
        {
            EndpointError,
            ServiceError,
        }
    }
}
