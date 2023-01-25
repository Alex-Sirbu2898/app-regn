using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regnology.Business;
using System.Net;

namespace Regnology.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StudentController(IMediator mediator, IMapper mapper, ILogger<StudentController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateStudentRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateStudentCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateStudentCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var query = new GetStudentByIdQuery(id);

            var result = await _mediator.Send(query,cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterStudentRequest request, CancellationToken cancellationToken)
        {
            var query =  _mapper.Map<FilterStudentQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if(id <= 0)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var command = _mapper.Map<DeleteStudentCommand>(id);

            var result = await _mediator.Send(command, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }
    }
}