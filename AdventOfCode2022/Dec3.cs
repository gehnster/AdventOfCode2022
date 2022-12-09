using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec3
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec3.txt";
            var lines = (await System.IO.File.ReadAllLinesAsync(path)).ToList();
            var prioritiesSum = 0;

            for (var i = 0; i < lines.Count; i += 3)
            {
                var badge = lines[i].ToCharArray().Intersect(lines[i + 1].ToCharArray())
                    .Intersect(lines[i + 2].ToCharArray());
                prioritiesSum += (int) Enum.Parse(typeof(ItemType), badge.First().ToString(), false);
            }

            Console.WriteLine("Priorities Sum: " + prioritiesSum);
        }
    }

    internal enum ItemType
    {
        a = 1,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j,
        k,
        l,
        m,
        n,
        o,
        p,
        q,
        r,
        s,
        t,
        u,
        v,
        w,
        x,
        y,
        z,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J, 
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }
}
