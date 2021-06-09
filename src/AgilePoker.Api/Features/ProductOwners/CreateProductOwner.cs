using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Models;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;

namespace AgilePoker.Api.Features
{
    public class CreateProductOwner
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProductOwner).NotNull();
                RuleFor(request => request.ProductOwner).SetValidator(new ProductOwnerValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProductOwnerDto ProductOwner { get; set; }
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
                var productOwner = new ProductOwner();
                
                _context.ProductOwners.Add(productOwner);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProductOwner = productOwner.ToDto()
                };
            }
            
        }
    }
}
