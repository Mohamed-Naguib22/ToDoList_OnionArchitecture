using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Context
{
    public class OnionArchitectureContext : DbContext
    {
        public OnionArchitectureContext(DbContextOptions<OnionArchitectureContext> options) : base(options)
        {
        }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
