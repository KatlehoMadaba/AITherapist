using Microsoft.AspNetCore.Mvc;
using aiTherapist.Services;
using System.Threading.Tasks;
namespace aiTherapist.Web.Host.Controllers
{
    public class AiTherapistController : ControllerBase
    {
        private readonly IAiTherapistService _aiTherapistService;
        public AiTherapistController(IAiTherapistService aiTherapistService)
        {
            _aiTherapistService = aiTherapistService;
        }
        [HttpPost("message")]
        public async Task<IActionResult> PostMessage([FromBody] UserMessageDto input)
        {
            var response = await _aiTherapistService.GetTherapistResponseAsync(input.Message);
            return Ok(new { reply = response });
        }

        public class UserMessageDto
        {
            public string Message { get; set; }
        }
    }
}
