using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AgilePoker.Api.Models;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;

namespace AgilePoker.Api.Features
{
    public class CreatePlanningSession
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
                var planningSession = new PlanningSession();
                
                _context.PlanningSessions.Add(planningSession);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PlanningSession = planningSession.ToDto()
                };
            }
            
        }
    }
}
