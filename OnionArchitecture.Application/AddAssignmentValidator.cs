using FluentValidation;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application
{
    public class AddAssignmentValidator : AbstractValidator<AddAssignmentDto>
    {
        public AddAssignmentValidator()
        {
                RuleFor(a => a.Name).MinimumLength(5);
        }
    }
}
