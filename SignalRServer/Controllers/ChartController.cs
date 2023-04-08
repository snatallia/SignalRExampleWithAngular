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
        private readonly IHubContext<ChartHub> hubContext;
        private readonly ChartTimer chartTimer;

        public ChartController(IHubContext<ChartHub> hubContext, ChartTimer chartTimer)
        {
            this.hubContext = hubContext;
            this.chartTimer = chartTimer;
        }

        public IActionResult Get()
        {
            if (!chartTimer.IsTimerStarted)
                chartTimer.PrepareTimer(() => hubContext.Clients.All.SendAsync("GetChartData", ChartData.GetData(5)));
            return Ok( new { Message = "Request completed." });
        }
    }
}
