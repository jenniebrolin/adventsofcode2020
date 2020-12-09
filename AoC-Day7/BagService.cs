using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AoC_Day7
{
    public class BagService
    {
        public Dictionary<string, HashSet<(int, string)>> Nodes = new Dictionary<string, HashSet<(int, string)>>();
        public HashSet<string> ancestors = new HashSet<string>();
        private List<(int, string)> countedbags = new List<(int, string)>();

        public int FindTheContainingBags(string resname = "AoC_Day7.rules.txt")
        {
            Nodes = GetBagNodes(resname).Where(r => r.Item2.Length > 0).ToDictionary(key => key.Item1, value => new HashSet<(int, string)>(value.Item2));
            var parents = Nodes.Where(kv => kv.Value.Select(v => v.Item2).Contains("shiny gold")).Select(kv => kv.Key);
            AddParentsOfValue(parents);
            return ancestors.Count();
        }

        void AddParentsOfValue(IEnumerable<string> parents)
        {
            foreach (var parent in parents)
            {
                if (ancestors.Contains(parent)) continue;
                ancestors.Add(parent);
                var gramps = Nodes.Where(kv => kv.Value.Select(v => v.Item2).Contains(parent) && !ancestors.Contains(kv.Key)).Select(k => k.Key);
                AddParentsOfValue(gramps);
            }
        }

        public int FindTheNoOfPackedBags(string resname = "AoC_Day7.rules.txt")
        {
            Nodes = GetBagNodes(resname).ToDictionary(key => key.Item1, value => new HashSet<(int, string)>(value.Item2));
            var gold = Nodes.Single(kv => kv.Key.Equals("shiny gold"));
            AddToNoOfBags(gold.Value);
            return countedbags.Sum(s => s.Item1);
        }

        void AddToNoOfBags(HashSet<(int, string)> kids)
        {
            foreach (var kid in kids)
            {
                countedbags.Add((kid.Item1, kid.Item2));
                var grandkids = Nodes[kid.Item2];
                for (int i = 0; i < kid.Item1; i++)
                    AddToNoOfBags(grandkids);
            }
        }

        public IEnumerable<(string, (int, string)[])> GetBagNodes(string resname)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resname);
            using var sr = new StreamReader(stream);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = SplitBig(line);
                var kids = parts.Skip(1).Select(s =>
                {
                    var bag = SplitSmall(s);
                    return (int.Parse(bag[0]), bag[1]);
                });

                yield return (parts[0], kids.ToArray());
            }
        }
    
        public static string[] SplitBig(string input)
        {
            string pattern = @"(?: bags contain no other bags.)|(?: bags contain )|(?: bags?[,.]?\s? ?)";
            var match = Regex.Split(input, pattern);
            return match.Take(match.Length - 1).ToArray();
            //Did not win against regexp :( Have to accept the ugly empty row, hence the Take...
        }

        public static string[] SplitSmall(string input)
        {
            string pattern = @"(?<=[0-9]+)(?:\s)";
            return Regex.Split(input, pattern);
        }        
    }
}
