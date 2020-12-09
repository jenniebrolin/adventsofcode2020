using AoC_Day8;
using System;
using Xunit;

namespace AoC_D8.Tests
{
    public class BootUpTests
    {
        [Fact]
        public void BootupLoopValue_All()
        {
            var bu = new BootUp();
            var res = bu.ValueBeforeEndlessLoop();
            Assert.Equal(1810, res);
        }

        [Fact]
        public void BootupLoopValue_Small()
        {
            var bu = new BootUp();
            var res = bu.ValueBeforeEndlessLoop("AoC_Day8.small.txt");
            Assert.Equal(3, res);
        }

        [Fact]
        public void BootupSuccessValue_All()
        {
            var bu = new BootUp();
            var res = bu.ValueFindTheCorrectLoop();
            Assert.Equal(969, res);
        }

        [Fact]
        public void BootupSuccessValue_Small()
        {
            var bu = new BootUp();
            var res = bu.ValueFindTheCorrectLoop("AoC_Day8.small.txt");
            Assert.Equal(5, res);
        }
    }
}
