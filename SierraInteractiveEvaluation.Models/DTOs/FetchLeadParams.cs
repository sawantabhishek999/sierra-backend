using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models
{
    public class FetchLeadParams
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
