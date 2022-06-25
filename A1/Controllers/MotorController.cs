using A1.BL.Interfaces;
using A1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace A1.Controllers
{
    [ApiController]
    [Route("controller")]
    public class MotorController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMq;

        public MotorController(IRabbitMqService rabbitMq)
        {
            _rabbitMq = rabbitMq;
        }

        [HttpPost("Publish Motor to RabbitMQ")]
        public async Task<IActionResult> ProduceMotor([FromBody] Motor motor)
        {
            await _rabbitMq.PublishMotorAsync(motor);

            return Ok();
        }
    }
}