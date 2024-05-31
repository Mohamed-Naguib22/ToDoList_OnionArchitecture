using OnionArchitecture.Application.Contract.IFeatures.ICommon;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Contract.IFeatures.IAssignment
{
    public interface IAssignmentService : IBaseService<Assignment, GetAssignmentDto, AddAssignmentDto, UpdateAssignmentDto>
    {
    }
}
