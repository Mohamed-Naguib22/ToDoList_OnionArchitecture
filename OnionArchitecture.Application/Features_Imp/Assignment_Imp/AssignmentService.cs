using AutoMapper;
using OnionArchitecture.Application.Contract.IFeatures.IAssignment;
using OnionArchitecture.Application.Contract.IRepositories.ICommon;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Application.Features_Imp.Common;
using OnionArchitecture.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features_Imp.Assignment_Imp
{
    public class AssignmentService : BaseService<Assignment, GetAssignmentDto, AddAssignmentDto, UpdateAssignmentDto>, IAssignmentService
    {
        public AssignmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
