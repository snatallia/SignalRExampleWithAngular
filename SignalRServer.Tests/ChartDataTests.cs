using NUnit.Framework;
using SignalRServer.Features;

namespace SignalRServer.Tests
{
    [TestFixture]
    public class ChartDataTests
    {
        [Test]
        public void ChartDataCount_Test1()
        {
            int result = ChartData.GetData(10).Count();
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void ChartDataCount_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ChartData.GetData(-1).ToList());

        }
    }
}