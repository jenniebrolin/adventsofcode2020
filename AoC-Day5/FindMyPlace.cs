using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC_Day5
{
    public class FindMyPlace
    {
        public int HighestNumber(string resfile = "AoC_Day5.seats.txt")
        {
            var occupied = GetAllSeats(resfile).ToArray();
            occupied = occupied.Distinct().OrderBy(o => o).ToArray();
            var taken = occupied.Select(s => OccupiedSeat(s)).ToArray();
            return taken.Max();
        }

        public int MyPlace(string resfile = "AoC_Day5.seats.txt")
        {
            var occupied = GetAllSeats(resfile).ToArray();
            occupied = occupied.Distinct().OrderBy(o => o).ToArray();
            var taken = occupied.Select(s => OccupiedSeat(s)).ToArray();
            var min = taken.Min();
            var allseats = Enumerable.Range(min + 1, taken.Length - 2).ToArray();
            var all = allseats.Where(n => taken.All(t => t != n)).ToList();
            return all[0];
        }

        public  int OccupiedSeat(string seat)
        {
            var row = seat.Take(7).Aggregate((0, 127), (lim, cval) =>
            {
                return cval == 'F' ? (lim.Item1, lim.Item1 + (lim.Item2 - lim.Item1) / 2) : ((lim.Item2 - (lim.Item2 - lim.Item1) / 2), lim.Item2);
            });
            var col = seat.Skip(7).Aggregate((0, 7), (lim, cval) =>
            {
                return cval == 'L' ? (lim.Item1, lim.Item1 + (lim.Item2 - lim.Item1) / 2) : ((lim.Item2 - (lim.Item2 - lim.Item1) / 2), lim.Item2);
            });
            return row.Item1 * 8 + col.Item1;
        }

        public string[] GetAllSeats(string resname)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resname);
            using var sr = new StreamReader(stream);
            return sr.ReadToEnd().Split(Environment.NewLine);  
        }
    }

}
