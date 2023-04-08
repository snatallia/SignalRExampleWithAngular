namespace SignalRServer.Models
{
    public class Chart
    {
        public List<int> Data { get; set; }
        public string? Info { get; set; }
        public Chart()
        {
            Data = new List<int>();
        }
    }
}
