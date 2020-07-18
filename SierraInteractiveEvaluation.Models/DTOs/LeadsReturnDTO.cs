using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models
{
    public class LeadsPaginatedReturnDTO
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<LeadsDTO> Leads { get; set; }
    }


    public class GetLeadsReturnDTO
    {
        public bool Success { get; set; }
        public LeadsPaginatedReturnDTO Data { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class GetLeadsDetailsDTO
    {
        public bool Success { get; set; }
        public Leads Data { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LeadsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string PasswordSalt { get; set; }
        //public string MD5PasswordHash { get; set; }
        public string LeadStatus { get; set; }
        public string ListingAgentStatus { get; set; }
        public string LenderStatus { get; set; }
        public string Email { get; set; }
        public string EmailStatus { get; set; }
        public string Phone { get; set; }
        public string PhoneStatus { get; set; }
        public string LeadType { get; set; }
        public DateTime CreationDate { get; set; }
        public string Source { get; set; }
        public bool MarketingEmailOptOut { get; set; }
        public bool TextOptOut { get; set; }
        public bool EAlertOptOut { get; set; }
        public AgentDTO AssignedTo { get; set; }
    }

    public class AgentDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SiteId { get; set; }
    }
}
