using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec4
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec4.txt";
            var lines = (await System.IO.File.ReadAllLinesAsync(path)).ToList();
            var totalContainedCleanings = 0;
            var cleaningGroups = lines.Select(x => x.Split(",").ToList());

            foreach (var group in cleaningGroups)
            {
                var firstElf = group.First().Split("-");
                var secondElf = group.Last().Split("-");

                if (long.Parse(firstElf.First()) >= long.Parse(secondElf.First()) &&
                    long.Parse(firstElf.First()) <= long.Parse(secondElf.Last()) ||
                    long.Parse(firstElf.Last()) <= long.Parse(secondElf.Last()) &&
                    long.Parse(firstElf.Last()) >= long.Parse(secondElf.Last()) ||
                    long.Parse(secondElf.First()) >= long.Parse(firstElf.First()) &&
                    long.Parse(secondElf.First()) <= long.Parse(firstElf.Last()) ||
                    long.Parse(secondElf.Last()) <= long.Parse(firstElf.Last()) &&
                    long.Parse(secondElf.Last()) >= long.Parse(firstElf.Last()))
                {
                    totalContainedCleanings += 1;
                }
            }

            Console.WriteLine("Total Contained Cleanings: " + totalContainedCleanings);
        }
    }
}
