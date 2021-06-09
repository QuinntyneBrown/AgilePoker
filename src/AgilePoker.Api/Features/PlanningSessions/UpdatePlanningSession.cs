using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class UpdatePlanningSession
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.PlanningSession).NotNull();
                RuleFor(request => request.PlanningSession).SetValidator(new PlanningSessionValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public PlanningSessionDto PlanningSession { get; set; }
        }

        public class Response: ResponseBase
        {
            public PlanningSessionDto PlanningSession { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var planningSession = await _context.PlanningSessions.SingleAsync(x => x.PlanningSessionId == request.PlanningSession.PlanningSessionId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PlanningSession = planningSession.ToDto()
                };
            }
            
        }
    }
}
