using System.Net;
using System.Threading.Tasks;
using AgilePoker.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgilePoker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanningSessionController
    {
        private readonly IMediator _mediator;

        public PlanningSessionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{planningSessionId}", Name = "GetPlanningSessionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlanningSessionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlanningSessionById.Response>> GetById([FromRoute]GetPlanningSessionById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.PlanningSession == null)
            {
                return new NotFoundObjectResult(request.PlanningSessionId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetPlanningSessionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlanningSessions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlanningSessions.Response>> Get()
            => await _mediator.Send(new GetPlanningSessions.Request());
        
        [HttpPost(Name = "CreatePlanningSessionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePlanningSession.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePlanningSession.Response>> Create([FromBody]CreatePlanningSession.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetPlanningSessionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPlanningSessionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPlanningSessionsPage.Response>> Page([FromRoute]GetPlanningSessionsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdatePlanningSessionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePlanningSession.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePlanningSession.Response>> Update([FromBody]UpdatePlanningSession.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{planningSessionId}", Name = "RemovePlanningSessionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePlanningSession.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePlanningSession.Response>> Remove([FromRoute]RemovePlanningSession.Request request)
            => await _mediator.Send(request);
        
    }
}
