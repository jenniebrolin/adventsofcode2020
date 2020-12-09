using System;
using Xunit;

namespace AoC_Day9.Tests
{
    public class NumbrGameTests
    {
        [Fact]
        public void Test()
        {
            var xmas = new NumberGame();
            var res = xmas.GetFirstOffender("AoC_Day9.test.txt");
            Assert.Equal(79, res);
        }

        [Fact]
        public void Xmas()
        {
            var xmas = new NumberGame();
            var res = xmas.GetFirstOffender();
            Assert.Equal(23278925, res);
        }

        [Fact]
        public void TestCont()
        {
            var xmas = new NumberGame();
            var res = xmas.GetContinuousSet("AoC_Day9.test.txt");
            Assert.Equal(54, res);
        }
        [Fact]
        public void MicroCont()
        {
            var xmas = new NumberGame();
            var res = xmas.GetContinuousSet("AoC_Day9.micro.txt");
            Assert.Equal(0, res);
        }

        [Fact]
        public void XmasCont()
        {
            var xmas = new NumberGame();
            var res = xmas.GetContinuousSet();
            Assert.Equal(4011064, res);
        }
    }
}
