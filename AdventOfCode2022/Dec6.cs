using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec6
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec6.txt";
            var line = (await System.IO.File.ReadAllLinesAsync(path)).ToList().First();
            var markerIndex = 0;

            for (var i = 0; i < line.Length-13; i ++)
            {
                var distinctElements = line.Substring(i, 14).Distinct();
                if (distinctElements.Count() == 14)
                {
                    markerIndex = i + 14;
                    break;
                }
            }

            Console.WriteLine("The marker is: " + markerIndex);
        }
    }
}
