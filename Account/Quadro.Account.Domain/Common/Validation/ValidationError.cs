using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Account.Domain.Common.Validation
{
    public class ValidationError
    {
        public string Message { get; set; }


        public ValidationError(string message)
        {
            Message = message;
        }

    }
}
