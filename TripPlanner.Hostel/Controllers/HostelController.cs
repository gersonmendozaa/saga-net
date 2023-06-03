
using TripPlanner.Hostel.Entities;
using TripPlanner.Hostel.Repositories.Interfaces;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TripPlanner.Hostel.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HostelController:ControllerBase
    {
        private readonly IHostelRepository _repository;
        private readonly ILogger<HostelController> _logger;

        public HostelController(IHostelRepository repository, ILogger<HostelController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HostelEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<HostelEntity>>> GetHostels()
        {
            var hostels = await _repository.GetHostel();
            return Ok(hostels);
        }

        [HttpGet("{id:length(24)}", Name = "GetHostel")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(HostelEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<HostelEntity>> GetHostelById(string id)
        {
            var hostel = await _repository.GetHostel(id);

            if (hostel == null)
            {
                _logger.LogError($"Hostel with id: {id}, not found.");
                return NotFound();
            }
            return Ok(hostel);
        }

        [Route("[action]/{name}", Name = "GetHostelByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<HostelEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<HostelEntity>>> GetHostelByName(string name)
        {
            var items = await _repository.GetHostelByName(name);
            if (items == null)
            {
                _logger.LogError($"Hostel with name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [ProducesResponseType(typeof(HostelEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<HostelEntity>> CreateHostel([FromBody] HostelEntity hostel)
        {
            await _repository.CreateHostel(hostel);

            return CreatedAtRoute("GetHostel", new { id = hostel.Id }, hostel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(HostelEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateHostel([FromBody] HostelEntity hostel)
        {
            return Ok(await _repository.UpdateHostel(hostel));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteHostel")]        
        [ProducesResponseType(typeof(HostelEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteHostelById(string id)
        {
            return Ok(await _repository.DeleteHostel(id));
        }
    }
}