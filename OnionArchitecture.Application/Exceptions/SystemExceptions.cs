using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base($"Data Not Found")
        {
        }

        public EntityNotFoundException(string message) : base($"{message} Not Found")
        {
        }
    }

    public class BadRequestException : Exception
    {
        public string[] Errors { get; set; }
        
        public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors;
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
    public class ValidationErrorException : Exception
    {

        public ValidationErrorException(string[] errors) : base("Multiple errors in Validation occurred. See error details.")
        {
            Errors = errors;
        }

        public string[] Errors { get; set; }
    }
}    