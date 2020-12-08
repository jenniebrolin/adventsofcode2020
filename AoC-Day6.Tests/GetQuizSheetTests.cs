using System;
using Xunit;

namespace AoC_Day6.Tests
{
    public class GetQuizSheetTests
    {
        [Fact]
        public void TestAsnwers_AtLeastOne()
        {
            var qs = new GetQuizSheet();
            var res = qs.GetAnswerResulAtLeastOne("AoC_Day6.test.txt");
            Assert.Equal(13, res); //4 + 5 + 4
        }

        [Fact]
        public void AllAsnwers_AtLestOne()
        {
            var qs = new GetQuizSheet();
            var res = qs.GetAnswerResulAtLeastOne();
            Assert.Equal(6161, res);
        }

        [Fact]
        public void TestAsnwers_All()
        {
            var qs = new GetQuizSheet();
            var res = qs.GetAnswerResultAll("AoC_Day6.test.txt");
            Assert.Equal(7, res); //2 + 3 + 2
        }

        [Fact]
        public void AllAsnwers_All()
        {
            var qs = new GetQuizSheet();
            var res = qs.GetAnswerResultAll();
            Assert.Equal(2971, res);
        }
    }
}
