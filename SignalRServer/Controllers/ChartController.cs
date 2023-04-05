using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Features;
using SignalRServer.HubConfig;
using System.Timers;

namespace SignalRServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hubContext;
        private readonly ChartTimer _timer;

        public ChartController(IHubContext<ChartHub> hubContext, ChartTimer timer)
        {
            _hubContext = hubContext;
            _timer = timer;
        }

        public IActionResult Get()
        {
            //_hubContext.Clients.All.SendAsync("getchartdata", ChartData.GetData());
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hubContext.Clients.All.SendAsync("GetChartData", ChartData.GetData()));
            return Ok( new { Message = "Request completed." });
        }
    }
}
