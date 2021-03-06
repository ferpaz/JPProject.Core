using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.IdentityResource
{
    public class IdentityResourceRegisteredEvent : Event
    {
        public IdentityResourceRegisteredEvent(string name)
            : base(EventTypes.Success)
        {
            AggregateId = name;
        }
    }
}