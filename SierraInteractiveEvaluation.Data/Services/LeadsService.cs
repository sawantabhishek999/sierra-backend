using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SierraInteractiveEvaluation.Models;
using SierraInteractiveEvaluation.Models.DTOs;
using SierraInteractiveEvaluation.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SierraInteractiveEvaluation.Models.Enums;

namespace SierraInteractiveEvaluation.Services
{
    public class LeadsService: ILeadsService
    {
        private readonly IOptions<SierraConfig> _sierraConfig;
        private readonly IMapper _mapper;
        static string apiName = "leads";
        public LeadsService(IOptions<SierraConfig> sierraConfig, IMapper mapper)
        {
            _sierraConfig = sierraConfig;
            _mapper = mapper;
        }
        public async Task<ReturnObject<CreateLeadReturnDTO>> Create(CreateLeadDTO leadObj)
        {
            try
            {
                // Validate leadObj params
                var validationObj = await ValidateLeadCreationParams(leadObj);

                if (validationObj.Count > 0)
                {
                   var validationMsg = string.Concat(validationObj.ToArray());
                   return ReturnHandler<CreateLeadReturnDTO>.GetReturnObject(true, null, validationMsg, null);
                }

                // make an Sierra API request to create lead
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_sierraConfig.Value.BaseUrl);
                    client.DefaultRequestHeaders.Add("Sierra-ApiKey", _sierraConfig.Value.APIKey);
                    var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(leadObj));
                    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                    var httpResponse = await client.PostAsync(apiName, httpContent);
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var apiResponseObj = JsonConvert.DeserializeObject<CreateLeadResponseDTO>(responseContent);
                    if (!apiResponseObj.Success)
                    {
                        return ReturnHandler<CreateLeadReturnDTO>.GetReturnObject(true, null, apiResponseObj.ErrorMessage, null);
                    }
                }
                return ReturnHandler<CreateLeadReturnDTO>.GetReturnObject(false, null, "Lead created successfully.", null);
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.ServiceError.ToString());
                return ReturnHandler<CreateLeadReturnDTO>.GetReturnObject(true, error, "Some Error occurred while creating lead.", null);
            }
        }

        private async Task<List<string>> ValidateLeadCreationParams(CreateLeadDTO leadObj)
        {
            try
            {
                List<string> lstValidationMsg = new List<string>();
                if (string.IsNullOrEmpty(leadObj.FirstName))
                {
                    lstValidationMsg.Add("First name is required.");
                }
                if (string.IsNullOrEmpty(leadObj.LastName))
                {
                    lstValidationMsg.Add("Last name is required.");
                }
                if (string.IsNullOrEmpty(leadObj.Password))
                {
                    lstValidationMsg.Add("Password is required.");
                }
                if (!Enum.IsDefined(typeof(LeadTypeEnum), leadObj.LeadType))
                {
                    lstValidationMsg.Add("Invalid leadtype. Should be buyer, lender or both.");
                }

                return lstValidationMsg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReturnObject<LeadsPaginatedReturnDTO>> GetLeads(FetchLeadParams fetchObj)
        {
            try
            {
                // sanitize parameters


                // make an Sierra API request to create lead
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_sierraConfig.Value.BaseUrl);
                    client.DefaultRequestHeaders.Add("Sierra-ApiKey", _sierraConfig.Value.APIKey);
                    var httpResponse = await client.GetAsync($"{apiName}/find?leadStatus=AllExceptDeleted&name={fetchObj.Name}&email={fetchObj.Email}&phone={fetchObj.Phone}&sortColumn=RegisteredDate&sortOrder=desc&pageSize={fetchObj.PageSize}&pageNumber={fetchObj.PageNumber}");
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var apiResponseObj = JsonConvert.DeserializeObject<GetLeadsReturnDTO>(responseContent);
                    if (!apiResponseObj.Success)
                    {
                        return ReturnHandler<LeadsPaginatedReturnDTO>.GetReturnObject(true, null, apiResponseObj.ErrorMessage, null);
                    }
                    var leadsData = _mapper.Map<LeadsPaginatedReturnDTO>(apiResponseObj.Data);
                    return ReturnHandler<LeadsPaginatedReturnDTO>.GetReturnObject(false, null, "Leads fetched successfully.", leadsData);
                }
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.ServiceError.ToString());
                return ReturnHandler<LeadsPaginatedReturnDTO>.GetReturnObject(true, error, "Some Error occurred while fetching leads.", null);
            }
        }

        public async Task<ReturnObject<LeadsDTO>> GetLeadById(int id)
        {
            try
            {
                // Validate leadObj params
                if (id == 0)
                {
                    return ReturnHandler<LeadsDTO>.GetReturnObject(true, null, "Please select valid lead.", null);
                }

                // make an Sierra API request to fetch lead details by id
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_sierraConfig.Value.BaseUrl);
                    client.DefaultRequestHeaders.Add("Sierra-ApiKey", _sierraConfig.Value.APIKey);
                    var httpResponse = await client.GetAsync($"{apiName}/get/{id}");
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var apiResponseObj = JsonConvert.DeserializeObject<GetLeadsDetailsDTO>(responseContent);
                    if (!apiResponseObj.Success)
                    {
                        return ReturnHandler<LeadsDTO>.GetReturnObject(true, null, apiResponseObj.ErrorMessage, null);
                    }
                    var leadsData = _mapper.Map<LeadsDTO>(apiResponseObj.Data);
                    return ReturnHandler<LeadsDTO>.GetReturnObject(false, null, "Lead details fetched successfully.", leadsData);
                }
            }
            catch (Exception ex)
            {
                var error = new Error("", ex.Message, ErrorTypeKeys.ServiceError.ToString());
                return ReturnHandler<LeadsDTO>.GetReturnObject(true, error, "Some Error occurred while fetching details.", null);
            }
        }
    }
}
