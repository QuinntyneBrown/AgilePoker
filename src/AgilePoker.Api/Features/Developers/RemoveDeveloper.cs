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
    public class RemoveDeveloper
    {
        public class Request: IRequest<Response>
        {
            public Guid DeveloperId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DeveloperDto Developer { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var developer = await _context.Developers.SingleAsync(x => x.DeveloperId == request.DeveloperId);
                
                _context.Developers.Remove(developer);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Developer = developer.ToDto()
                };
            }
            
        }
    }
}
