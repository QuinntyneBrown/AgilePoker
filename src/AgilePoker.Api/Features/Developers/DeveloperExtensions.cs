using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class DeveloperExtensions
    {
        public static DeveloperDto ToDto(this Developer developer)
        {
            return new ()
            {
                DeveloperId = developer.DeveloperId
            };
        }
        
    }
}
