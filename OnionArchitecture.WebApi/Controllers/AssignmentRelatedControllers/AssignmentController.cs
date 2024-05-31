using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Contract.IFeatures.IAssignment;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Domain.Models.Entities;
using OnionArchitecture.WebApi.Controllers.Common;

namespace OnionArchitecture.WebApi.Controllers.AssignmentRelatedControllers
{
    public class AssignmentController : BaseController<Assignment, GetAssignmentDto, AddAssignmentDto, UpdateAssignmentDto>
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService) : base(assignmentService)
        {
            _assignmentService = assignmentService;
        }
    }
}
