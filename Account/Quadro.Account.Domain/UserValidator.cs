
using Quadro.Core.Domain.Validation;

namespace Quadro.Account.Domain;

    public class UserValidator : CompositeValidator<User>
    {
        public UserValidator()
        {
            AddValidator(new UserNameMustBeUpperCaseValidator());
        }
    }

    public class UserNameMustBeUpperCaseValidator : SpecificationBasedValidator<User>
    {
        public UserNameMustBeUpperCaseValidator() : base(new UserNameUpperCaseSpecification())
        {
        }

        protected override ValidationError GetError(User entity)
        {
            return new ValidationError("User Name can contain only upper case characters");
        }
    }

