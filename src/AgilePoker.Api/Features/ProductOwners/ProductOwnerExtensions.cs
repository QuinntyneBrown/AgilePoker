using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class ProductOwnerExtensions
    {
        public static ProductOwnerDto ToDto(this ProductOwner productOwner)
        {
            return new ()
            {
                ProductOwnerId = productOwner.ProductOwnerId
            };
        }
        
    }
}
