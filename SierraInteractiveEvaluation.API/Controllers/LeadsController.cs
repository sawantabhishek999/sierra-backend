using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SierraInteractiveEvaluation.Models;
using SierraInteractiveEvaluation.Services;
using static SierraInteractiveEvaluation.Models.Enums;

namespace SierraInteractiveEvaluation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsService _leadsService;

        public LeadsController(ILeadsService leadsService)
        {
            _leadsService = leadsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string name,  string phone, string email, int? pageNumber = 1, int? pageSize = 25)
        {
            try
            {
                var filterObj = new FetchLeadParams()
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    PageNumber = (int)pageNumber,
                    PageSize = (int)pageSize
                };
                var createdLeadObj = await _leadsService.GetLeads(filterObj);
                if (createdLeadObj.IsError)
                {
                    return BadRequest(createdLeadObj);
                }
                return Ok(createdLeadObj);
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.EndpointError.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var leadObj = await _leadsService.GetLeadById(id);
                if (leadObj.IsError)
                {
                    return BadRequest(leadObj);
                }
                return Ok(leadObj);
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.EndpointError.ToString());
                return BadRequest(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeadDTO obj)
        {
            try
            {
                var createdLeadObj = await _leadsService.Create(obj);
                if (createdLeadObj.IsError)
                {
                    return BadRequest(createdLeadObj);
                }
                return Ok(createdLeadObj);
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.EndpointError.ToString());
                return BadRequest(error);
            }
        }
    }
}