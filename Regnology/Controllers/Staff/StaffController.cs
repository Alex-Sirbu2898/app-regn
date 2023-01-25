using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regnology.Business;

namespace Regnology.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {

        private readonly ILogger<StaffController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StaffController(IMediator mediator, IMapper mapper, ILogger<StaffController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateStaffRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CreateStaffCommand>(request);

            var result = await _mediator.Send(query,cancellationToken);

            return Ok(result);
        }

        //[HttpPut()]
        //public async Task<IActionResult> Put([FromBody] UpdateStudentRequest request, CancellationToken cancellationToken)
        //{
        //    var query = _mapper.Map<UpdateStudentCommand>(request);

        //    var result = await _mediator.Send(query,cancellationToken);

        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        //{
        //    var query = new GetStudentByIdQuery(id);

        //    var result = await _mediator.Send(query,cancellationToken);

        //    return result is null ? (IActionResult)NotFound() : Ok(result);
        //}
    }
}