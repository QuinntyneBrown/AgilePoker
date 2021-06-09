using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class GetPlanningSessions
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<PlanningSessionDto> PlanningSessions { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    PlanningSessions = await _context.PlanningSessions.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
