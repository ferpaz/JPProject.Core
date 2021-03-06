using System;
using FluentValidation;
using JPProject.Admin.Domain.Commands.IdentityResource;

namespace JPProject.Admin.Domain.Validations.IdentityResource
{
    public abstract class IdentityResourceValidation<T> : AbstractValidator<T> where T : IdentityResourceCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Resource.Name).NotEmpty().WithMessage("Invalid resource name");
        }

    }
}