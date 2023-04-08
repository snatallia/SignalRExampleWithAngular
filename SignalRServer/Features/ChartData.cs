using SignalRServer.Models;
using System.Runtime.CompilerServices;

namespace SignalRServer.Features
{
    public class ChartData
    {
        public static IEnumerable<Chart> GetData(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be higher 0");

            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                yield return new Chart { Data = new List<int> { random.Next(1, 100) }, Info = $"Data info {i}" };
            }           
        }
    }
}
