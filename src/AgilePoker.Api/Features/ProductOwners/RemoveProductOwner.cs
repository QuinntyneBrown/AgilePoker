using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AgilePoker.Api.Models;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;

namespace AgilePoker.Api.Features
{
    public class RemoveProductOwner
    {
        public class Request: IRequest<Response>
        {
            public Guid ProductOwnerId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductOwnerDto ProductOwner { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var productOwner = await _context.ProductOwners.SingleAsync(x => x.ProductOwnerId == request.ProductOwnerId);
                
                _context.ProductOwners.Remove(productOwner);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProductOwner = productOwner.ToDto()
                };
            }
            
        }
    }
}
