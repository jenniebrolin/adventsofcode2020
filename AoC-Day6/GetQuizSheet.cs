using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC_Day6
{
    public class GetQuizSheet
    {
        public int GetAnswerResulAtLeastOne(string resname = "AoC_Day6.answers.txt")
        {
            var groups = GetQuizGroups(resname).ToList();
            return groups.Sum();
        }
        public int GetAnswerResultAll(string resname = "AoC_Day6.answers.txt")
        {
            var groups = GetQuizGroups(resname, false).ToList();
            return groups.Sum();
        }

        public IEnumerable<int> GetQuizGroups(string resname = "", bool atleastone = true)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resname))
            using (var sr = new StreamReader(stream))
            {
                string line;
                Dictionary<int, int> grouphug = new Dictionary<int, int>();
                var groupcount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == string.Empty)
                    {
                        var res = grouphug.Count(kv => atleastone || kv.Value == groupcount);
                        grouphug = new Dictionary<int, int>();
                        groupcount = 0;
                        yield return res;
                        continue;
                    }
                    groupcount++;
                    line.ToCharArray().All(c =>
                    {
                        if (!grouphug.TryAdd(c, 1)) grouphug[c] += 1;
                        return true;
                    });           
                }
                yield return grouphug.Count(kv => atleastone || kv.Value == groupcount);
            }
        }
    }
}
