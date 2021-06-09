using System.Net;
using System.Threading.Tasks;
using AgilePoker.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgilePoker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductOwnerController
    {
        private readonly IMediator _mediator;

        public ProductOwnerController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{productOwnerId}", Name = "GetProductOwnerByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductOwnerById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductOwnerById.Response>> GetById([FromRoute]GetProductOwnerById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.ProductOwner == null)
            {
                return new NotFoundObjectResult(request.ProductOwnerId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetProductOwnersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductOwners.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductOwners.Response>> Get()
            => await _mediator.Send(new GetProductOwners.Request());
        
        [HttpPost(Name = "CreateProductOwnerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProductOwner.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProductOwner.Response>> Create([FromBody]CreateProductOwner.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetProductOwnersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductOwnersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductOwnersPage.Response>> Page([FromRoute]GetProductOwnersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateProductOwnerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProductOwner.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProductOwner.Response>> Update([FromBody]UpdateProductOwner.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{productOwnerId}", Name = "RemoveProductOwnerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProductOwner.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProductOwner.Response>> Remove([FromRoute]RemoveProductOwner.Request request)
            => await _mediator.Send(request);
        
    }
}
