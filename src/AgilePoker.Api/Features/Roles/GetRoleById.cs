using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class GetRoleById
    {
        public class Request: IRequest<Response>
        {
            public Guid RoleId { get; set; }
        }

        public class Response: ResponseBase
        {
            public RoleDto Role { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Role = (await _context.Roles.SingleOrDefaultAsync(x => x.RoleId == request.RoleId)).ToDto()
                };
            }
            
        }
    }
}
