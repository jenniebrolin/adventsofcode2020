using AoC_Day7;
using Xunit;

namespace Day7.Tests
{
    public class BagServiceTests
    {
        [Fact]
        public void TestSplitManyBags()
        {
            var parts = BagService.SplitBig("striped orange bags contain 1 vibrant green bag, 5 plaid yellow bags, 1 drab magenta bag.");
            Assert.Equal("striped orange", parts[0]);
            Assert.Equal("vibrant green", BagService.SplitSmall(parts[1])[0]);
            Assert.Equal("plaid yellow", BagService.SplitSmall(parts[2])[0]);
            Assert.Equal("drab magenta", BagService.SplitSmall(parts[3])[0]);
            Assert.Equal(4, parts.Length);
        }

        [Fact]
        public void TestNoBags()
        {
            var parts = BagService.SplitBig("pale purple bags contain no other bags.");
            Assert.Equal("pale purple", parts[0]);
            Assert.Single(parts);
        }

        [Fact]
        public void HowManyPacksShinyGold_All()
        {
            var bs = new BagService();
            var count = bs.FindTheContainingBags();
            Assert.Equal(584, bs.Nodes.Count);
            Assert.True(316 == count);
        }

        [Fact]
        public void HowManyPacksShinyGold_Small()
        {
            var bs = new BagService();
            var count = bs.FindTheContainingBags("AoC_Day7.test.txt");
            Assert.Equal(4, bs.Nodes.Count);
            Assert.True(2 == count);
        }

        [Fact]
        public void HowManyMustShinyGoldPack_All()
        {
            var bs = new BagService();
            var count = bs.FindTheNoOfPackedBags();
            Assert.Equal(584, bs.Nodes.Count);
            Assert.True(316 == count);
        }

        [Fact]
        public void HowManyMustShinyGoldPack_Small()
        {
            var bs = new BagService();
            var count = bs.FindTheNoOfPackedBags("AoC_Day7.test.txt");
            Assert.Equal(5, bs.Nodes.Count);
            Assert.True(30 == count);
        }
    }
}
