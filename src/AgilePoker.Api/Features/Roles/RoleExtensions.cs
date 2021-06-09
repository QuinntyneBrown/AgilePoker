using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class RoleExtensions
    {
        public static RoleDto ToDto(this Role role)
        {
            return new ()
            {
                RoleId = role.RoleId
            };
        }
        
    }
}
