using Task2;
using Xunit;

namespace Tests.Task2Should
{
    public class PrimarySearchServiceShould
    {
        PrimarySearchService _primarySearchService = new PrimarySearchService();

        [Fact]
        public void ReturnTrueCounterOfHundred()
        {
            _primarySearchService.PrimarySearch(new Settings(-100, 100));
            Assert.Equal(25, _primarySearchService.GetResultCollection().Count);
        }
        [Fact]
        public void ReturnTrueCounterOfFirstFiveHundredPrimaries()
        {
            _primarySearchService.PrimarySearch(new Settings(0, 3572));
            Assert.Equal(500, _primarySearchService.GetResultCollection().Count);
        }
    }
}
