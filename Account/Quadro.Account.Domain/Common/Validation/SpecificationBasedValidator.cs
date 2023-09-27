using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Quadro.Account.Domain.Common.Validation
{
    public abstract class SpecificationBasedValidator<T> : IValidator<T>
    {
        public Specification<T> Specification { get; }

        protected SpecificationBasedValidator(Specification<T> specification)
        {
            Guard.Against.Null(specification, nameof(specification));
            Specification = specification;
        }

        public ValidationResult Validate(T entity)
        {
            var validationResult = new ValidationResult();
            if (!Specification.IsSatisfiedBy(entity))
            {
                validationResult.AddError(GetError(entity));
            }
            return validationResult;
        }

        protected abstract ValidationError GetError(T entity);
    }
}
