using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SierraInteractiveEvaluation.Models.Enums;

namespace SierraInteractiveEvaluation.Models
{
    public class CreateLeadDTO
    {
        // [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        // [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //    ErrorMessage = "Email is required and should be in proper format.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SourceType { get; set; }
        // [EnumValidation(AllowUnKnown = false)]
        public LeadTypeEnum LeadType { get; set; }
        public string[] Tags { get; set; }
        public string Note { get; set; }
        public bool SendRegistrationEmail { get; set; }
    }


    public class CreateLeadResponseDTO
    {
        public bool Success { get; set; }
        public JObject Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
