using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regnology.Business;
using System.Net;

namespace Regnology.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByIdQuery(id);

            var result = await _mediator.Send(query,cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query =  _mapper.Map<FilterEmployeeQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if(id <= 0)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var command = _mapper.Map<DeleteEmployeeCommand>(id);

            var result = await _mediator.Send(command, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }
    }
}