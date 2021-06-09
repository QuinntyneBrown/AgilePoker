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
    public class RemoveInvite
    {
        public class Request: IRequest<Response>
        {
            public Guid InviteId { get; set; }
        }

        public class Response: ResponseBase
        {
            public InviteDto Invite { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var invite = await _context.Invites.SingleAsync(x => x.InviteId == request.InviteId);
                
                _context.Invites.Remove(invite);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Invite = invite.ToDto()
                };
            }
            
        }
    }
}
