using SignalRServer.Models;

namespace SignalRServer.Features
{
    public class ChartData
    {
        public static List<Chart> GetData()
        { 
            var random = new Random();
            return new List<Chart>
            {
                new Chart{ Data = new List<int> { random.Next(1,100) }, Info = "Data info 1" },
                new Chart{ Data = new List<int> { random.Next(1,100) }, Info = "Data info 2" },
                new Chart{ Data = new List<int> { random.Next(1,100) }, Info = "Data info 3" },
                new Chart{ Data = new List<int> { random.Next(1,100) }, Info = "Data info 4" },
                new Chart{ Data = new List<int> { random.Next(1,100) }, Info = "Data info 5" },
            };
        }
    }
}
