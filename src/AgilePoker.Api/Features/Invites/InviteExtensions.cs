using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class InviteExtensions
    {
        public static InviteDto ToDto(this Invite invite)
        {
            return new ()
            {
                InviteId = invite.InviteId
            };
        }
        
    }
}
