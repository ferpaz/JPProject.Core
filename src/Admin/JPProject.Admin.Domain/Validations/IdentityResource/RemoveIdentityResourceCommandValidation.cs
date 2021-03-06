using JPProject.Admin.Domain.Commands.IdentityResource;

namespace JPProject.Admin.Domain.Validations.IdentityResource
{
    public class RemoveIdentityResourceCommandValidation : IdentityResourceValidation<RemoveIdentityResourceCommand>
    {
        public RemoveIdentityResourceCommandValidation()
        {
            ValidateName();
        }
    }
}