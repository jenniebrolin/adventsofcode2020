using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC_Day9
{
    public class NumberGame
    {
        public Int64 GetFirstOffender(string resfile = "AoC_Day9.xmas.txt")
        {
            var nums = GetNumbers(resfile);
            return GetOffender(nums);
        }

        public Int64 GetContinuousSet(string resfile = "AoC_Day9.xmas.txt")
        {
            var nums = GetNumbers(resfile);
            var offender = GetOffender(nums);
            var set = ContinuousSet(nums, offender);
            return set.Min() + set.Max();
        }

        private Int64[] ContinuousSet(Int64[] nums, Int64 offender)
        {
            //find index of offender
            for (var j = 0; j < nums.Length-1; j++)
                for (var k = 1 + j; k < nums.Length; k++)
                {
                    var series = nums.Skip(j).Take(k+1-j).ToArray();
                    var sum = series.Sum();
                    if (sum > offender)
                        break;
                    if (sum == offender)
                        return series; 
                }

            return new Int64[2] { 0, 0 };
        }

        private Int64 GetOffender(Int64[] nums)
        {
            int len = nums.Length - 25;
            for (int i = 0; i < len; i++)
            {
                Int64[] preamble = nums.Take(25).ToArray();
                var found = false;
                for (var j = 0; j < 24; j++)
                {
                    for (var k = 1 + j; k < 25; k++)
                        if (preamble[j] + preamble[k] == nums[25])
                        {
                            found = true;
                            break;
                        }
                    if (found) break;
                }
                if (!found)
                    return nums[25];
                nums = nums.Skip(1).ToArray();
            }

            return -1;
        }

        public Int64[] GetNumbers(string resname)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resname);
            using var sr = new StreamReader(stream);
            return sr.ReadToEnd().Split(Environment.NewLine).Select(Int64.Parse).ToArray();
        }
    }
}
