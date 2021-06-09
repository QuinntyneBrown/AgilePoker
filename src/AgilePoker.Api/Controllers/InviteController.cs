using System.Net;
using System.Threading.Tasks;
using AgilePoker.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgilePoker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InviteController
    {
        private readonly IMediator _mediator;

        public InviteController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{inviteId}", Name = "GetInviteByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInviteById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInviteById.Response>> GetById([FromRoute]GetInviteById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Invite == null)
            {
                return new NotFoundObjectResult(request.InviteId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetInvitesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInvites.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInvites.Response>> Get()
            => await _mediator.Send(new GetInvites.Request());
        
        [HttpPost(Name = "CreateInviteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateInvite.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateInvite.Response>> Create([FromBody]CreateInvite.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetInvitesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetInvitesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetInvitesPage.Response>> Page([FromRoute]GetInvitesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateInviteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateInvite.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateInvite.Response>> Update([FromBody]UpdateInvite.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{inviteId}", Name = "RemoveInviteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveInvite.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveInvite.Response>> Remove([FromRoute]RemoveInvite.Request request)
            => await _mediator.Send(request);
        
    }
}
