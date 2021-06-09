using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class UpdateDeveloper
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Developer).NotNull();
                RuleFor(request => request.Developer).SetValidator(new DeveloperValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public DeveloperDto Developer { get; set; }
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
                var developer = await _context.Developers.SingleAsync(x => x.DeveloperId == request.Developer.DeveloperId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Developer = developer.ToDto()
                };
            }
            
        }
    }
}
