using OnionArchitecture.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Models.Entities
{
    public class Assignment : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
