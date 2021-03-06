using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class UpdateInvite
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Invite).NotNull();
                RuleFor(request => request.Invite).SetValidator(new InviteValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public InviteDto Invite { get; set; }
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
                var invite = await _context.Invites.SingleAsync(x => x.InviteId == request.Invite.InviteId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Invite = invite.ToDto()
                };
            }
            
        }
    }
}
