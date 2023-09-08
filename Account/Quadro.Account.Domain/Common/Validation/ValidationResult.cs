using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quadro.Account.Domain.Common.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new();

        public bool IsValid => _errors.Count == 0;

        public IEnumerable<ValidationError> Errors => _errors;

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public void RemoveError(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        public void Combine(ValidationResult result)
        {
            foreach (var validationError in result.Errors)
            {
                AddError(validationError);
            }
        }
    }
}
