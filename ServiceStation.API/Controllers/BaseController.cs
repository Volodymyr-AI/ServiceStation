using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ServiceStation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        public IMediator _mediator;
        public IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
