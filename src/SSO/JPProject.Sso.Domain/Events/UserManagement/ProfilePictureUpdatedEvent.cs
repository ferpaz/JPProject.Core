﻿using System;
using JPProject.Domain.Core.Events;

namespace JPProject.Sso.Domain.Events.UserManagement
{
    public class ProfilePictureUpdatedEvent : Event
    {
        public string Picture { get; }

        public ProfilePictureUpdatedEvent(string username, string picture)
            : base(EventTypes.Success)
        {
            AggregateId = username;
            Picture = picture;
        }
    }
}