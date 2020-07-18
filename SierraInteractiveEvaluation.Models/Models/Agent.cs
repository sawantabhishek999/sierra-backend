using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models
{
    public class Agent
    {
        public int AgentUserId { get; set; }
        public string AgentUserEmail { get; set; }
        public string AgentUserPhone { get; set; }
        public string AgentUserFirstName { get; set; }
        public string AgentUserLastName { get; set; }
        public int AgentSiteId { get; set; }
    }
}
