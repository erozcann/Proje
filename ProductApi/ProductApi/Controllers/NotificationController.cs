using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProductApi.Hubs;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public NotificationController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("send")]
        public async Task<IActionResult> SendMessage()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Yeni bir sipariş alındı!");
            return Ok(new { message = "Mesaj gönderildi" });
        }
    }
}
