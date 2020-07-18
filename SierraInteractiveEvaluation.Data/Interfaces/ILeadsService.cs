using SierraInteractiveEvaluation.Models;
using SierraInteractiveEvaluation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SierraInteractiveEvaluation.Services
{
    public interface ILeadsService
    {
        Task<ReturnObject<CreateLeadReturnDTO>> Create(CreateLeadDTO leadObj);
        Task<ReturnObject<LeadsPaginatedReturnDTO>> GetLeads(FetchLeadParams fetchObj);
        Task<ReturnObject<LeadsDTO>> GetLeadById(int id);
    }
}
