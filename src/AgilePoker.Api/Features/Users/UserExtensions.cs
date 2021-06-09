using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new ()
            {
                UserId = user.UserId
            };
        }
        
    }
}
