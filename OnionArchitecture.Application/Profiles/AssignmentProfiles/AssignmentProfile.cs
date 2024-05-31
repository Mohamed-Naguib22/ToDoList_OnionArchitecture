using AutoMapper;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Profiles.AssignmentProfiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
           CreateMap<Assignment, GetAssignmentDto>().ReverseMap();
           CreateMap<AddAssignmentDto, Assignment>().ReverseMap();
           CreateMap<UpdateAssignmentDto, Assignment>().ReverseMap();
        }
    }
}
