using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AgilePoker.Api.Extensions;
using AgilePoker.Api.Core;
using AgilePoker.Api.Interfaces;
using AgilePoker.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Features
{
    public class GetPlanningSessionsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<PlanningSessionDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAgilePokerDbContext _context;
        
            public Handler(IAgilePokerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from planningSession in _context.PlanningSessions
                    select planningSession;
                
                var length = await _context.PlanningSessions.CountAsync();
                
                var planningSessions = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = planningSessions
                };
            }
            
        }
    }
}
