using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Dtos.AssignmentDtos
{
    public class AddAssignmentDto
    {
        [StringLength(2)]
        public string Name { get; set; }
        [StringLength(2)]
        public string Description { get; set; }
    }
}
