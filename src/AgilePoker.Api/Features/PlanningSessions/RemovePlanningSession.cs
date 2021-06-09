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
    public class RemovePlanningSession
    {
        public class Request: IRequest<Response>
        {
            public Guid PlanningSessionId { get; set; }
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
                var planningSession = await _context.PlanningSessions.SingleAsync(x => x.PlanningSessionId == request.PlanningSessionId);
                
                _context.PlanningSessions.Remove(planningSession);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    PlanningSession = planningSession.ToDto()
                };
            }
            
        }
    }
}
