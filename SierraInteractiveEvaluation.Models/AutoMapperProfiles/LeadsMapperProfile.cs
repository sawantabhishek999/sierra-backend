using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Models.AutoMapperProfiles
{
    public class LeadsMapperProfile: Profile
    {
        public LeadsMapperProfile()
        {
            CreateMap<Leads, LeadsDTO>();
            CreateMap<Agent, AgentDTO>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.MapFrom(src => src.AgentUserId);
                }).ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.AgentUserEmail);
                }).ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.AgentUserFirstName);
                }).ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.AgentUserLastName);
                }).ForMember(dest => dest.Phone, opt =>
                {
                    opt.MapFrom(src => src.AgentUserPhone);
                });            
        }
    }
}
