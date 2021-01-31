using Task1;
using Xunit;

namespace Tests.Task1Shoukd
{
    public class SearchersShould
    {
        IPrimarySearcher[] _searchers = new IPrimarySearcher[] { new LinqPrimarySearcher(), new PlinqPrimarySearcher() };

        [Theory]
        [InlineData(96, 100000)]
        [InlineData(2, 9542)]
        [InlineData(9, 37564)]
        [InlineData(30, 59)]
        public void ReturnTheSameResult(int start, int finish)
        {
            Assert.Equal(_searchers[0].SearchPrimary(start, finish), _searchers[1].SearchPrimary(start, finish));
        }
        [Fact]
        public void LinqReturnTrueCounterOfHundred()
        {
            Assert.Equal(25, _searchers[1].SearchPrimary(2,100));
        }
        [Fact]
        public void LinqReturnTrueCounterOfFirstFiveHundredPrimaries()
        {
            Assert.Equal(500, _searchers[1].SearchPrimary(2, 3572));
        }
    }
}
