using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Models;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;

namespace AgilePoker.Api.Features
{
    public class CreateRole
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Role).NotNull();
                RuleFor(request => request.Role).SetValidator(new RoleValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public RoleDto Role { get; set; }
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
                var role = new Role();
                
                _context.Roles.Add(role);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Role = role.ToDto()
                };
            }
            
        }
    }
}
