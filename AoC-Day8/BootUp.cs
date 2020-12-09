using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC_Day8
{
    public class BootUp
    {

        public int ValueBeforeEndlessLoop(string resname = "AoC_Day8.boot.txt")
        {
            var instructions = GetInstructions(resname);
            return HopAlong(instructions, instructions.First());
        }

        public int ValueFindTheCorrectLoop(string resname = "AoC_Day8.boot.txt")
        {
            var instructions = GetInstructions(resname);
            foreach (var action in instructions)
            {
                if (action.Item3 == 'a') continue;
                (int, int, char)[] tmp = new (int, int, char)[instructions.Count];
                instructions.CopyTo(tmp);
                HashSet<(int, int, char)> newdeal = new HashSet<(int, int, char)>(tmp);
                var rem = newdeal.Remove(action);
                var switchaction = (action.Item1, action.Item2, (action.Item3 == 'j' ? 'n' : 'j'));
                newdeal.Add(switchaction);                
                var res = HopAlong(newdeal, newdeal.Single(a => a.Item1 == newdeal.Min(a => a.Item1)), false);
                if (res != 0) return res;
            }

            return 0;
        }
        
        private int HopAlong(HashSet<(int, int, char)> bootup, (int, int, char) current, bool findtheloop = true)
        {
            HashSet<int> path = new HashSet<int>();
            int value = 0;
            do
            {
                path.Add(current.Item1); 
                value += current.Item3 == 'a' ? current.Item2 : 0; //acc inc if any;
                var move = current.Item1 + (current.Item3 == 'j' ? current.Item2 : 1);
                if (move == bootup.Count+1)
                    return value; //success!!!
                if (move > bootup.Count + 1)
                    return 0;
                var peek = bootup.Single(p => p.Item1 == move);
                if (peek.Item1 == 0)
                    return 0;
                if (path.Contains(peek.Item1))
                    return findtheloop ? value : 0;
                current = peek;
            }
            while (true);
        }

        public HashSet<(int, int, char)> GetInstructions(string resname)
        {
            HashSet<(int, int, char)> bootup = new HashSet<(int, int, char)>();
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resname);
            using var sr = new StreamReader(stream);
            int i = 1;
            var lines = sr.ReadToEnd().Split(Environment.NewLine).All(s =>
            {
                bootup.Add((i++, int.Parse(s[4] + s[5..]), s[0]));
                return true;
            });
            return bootup;
        }
    }
}
