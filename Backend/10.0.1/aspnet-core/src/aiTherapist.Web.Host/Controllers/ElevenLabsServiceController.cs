using aiTherapist.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aiTherapist.Web.Host.Controllers
{
    [Route("api/ai-therapist")]
    [ApiController]
    public class ElevenLabsServiceController : ControllerBase
    {
        private readonly ElevenLabsService _aiTherapistService;

        public ElevenLabsServiceController(ElevenLabsService aiTherapistService)
        {
            _aiTherapistService = aiTherapistService;
        }

        [HttpPost("speak")]
        public async Task<IActionResult> Speak([FromBody] SpeakRequestDto request)
        {
            var audioBytes = await _aiTherapistService.GetSpeechFromTextAsync(request.Text);
            return File(audioBytes, "audio/mpeg");
        }

        public class SpeakRequestDto
        {
            public string Text { get; set; }
        }
    }
}
