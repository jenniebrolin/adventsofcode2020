using System;
using Xunit;

namespace AoC_Day5.Tests
{
    public class FinMyPlaceTests
    {
        [Fact]
        public void GetTheSeatNo()
        {
            var mp = new FindMyPlace();
            var res = mp.OccupiedSeat("FBFBBFFRLR");
            Assert.Equal(357, res);
        }

        [Fact]
        public void GetTheFirstSeatNo()
        {
            var mp = new FindMyPlace();
            var res = mp.OccupiedSeat("FFFFFFFLLL");
            Assert.Equal(0, res);
        }

        [Fact]
        public void GetTheFirstSeatNo_1()
        {
            var mp = new FindMyPlace();
            var res = mp.OccupiedSeat("FFFFFFFLLR");
            Assert.Equal(1, res);
        }

        [Fact]
        public void GetTheFirstSeatNo_562()
        {
            var mp = new FindMyPlace();
            var res = mp.OccupiedSeat("BFFFBBFLRL");
            Assert.Equal(562, res);
        }

        //BFFFBBFRRR => 567
        [Fact]
        public void GetTheFirstSeatNo_567()
        {
            var mp = new FindMyPlace();
            var res = mp.OccupiedSeat("BFFFBBFRRR");
            Assert.Equal(567, res);
        }

        [Fact]
        public void GetTheHighestNO()
        {
            var mp = new FindMyPlace();
            var res = mp.HighestNumber();
            Assert.Equal(806, res);
        }

        [Fact]
        public void FIndMySeat()
        {
            var mp = new FindMyPlace();
            var res = mp.MyPlace();
            Assert.Equal(357, res);
        }
    }
}
