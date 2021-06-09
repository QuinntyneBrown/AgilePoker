using System.Net;
using System.Threading.Tasks;
using AgilePoker.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgilePoker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController
    {
        private readonly IMediator _mediator;

        public DeveloperController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{developerId}", Name = "GetDeveloperByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDeveloperById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDeveloperById.Response>> GetById([FromRoute]GetDeveloperById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Developer == null)
            {
                return new NotFoundObjectResult(request.DeveloperId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetDevelopersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDevelopers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDevelopers.Response>> Get()
            => await _mediator.Send(new GetDevelopers.Request());
        
        [HttpPost(Name = "CreateDeveloperRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDeveloper.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDeveloper.Response>> Create([FromBody]CreateDeveloper.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetDevelopersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDevelopersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDevelopersPage.Response>> Page([FromRoute]GetDevelopersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateDeveloperRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDeveloper.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDeveloper.Response>> Update([FromBody]UpdateDeveloper.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{developerId}", Name = "RemoveDeveloperRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDeveloper.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDeveloper.Response>> Remove([FromRoute]RemoveDeveloper.Request request)
            => await _mediator.Send(request);
        
    }
}
