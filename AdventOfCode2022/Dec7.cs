using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec7
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec7.txt";
            var lines = (await System.IO.File.ReadAllLinesAsync(path));
            var sumOfDirectoriesSize = 0L;
            var fileSystem = new Directory() {Name = "/", PreviousDirectory = null};
            var currentLocation = fileSystem;
            var currentCommand = CurrentCommand.ListDirectory;

            foreach (var line in lines)
            {
                var splitLine = line.Split(' ');
                if (splitLine.First() == "$")
                {
                    if (splitLine[1] == "ls")
                    {
                        currentCommand = CurrentCommand.ListDirectory;
                        continue;
                    }
                    else if (splitLine[1] == "cd")
                    {
                        if (splitLine[2] == "/")
                        {
                            currentLocation = fileSystem;
                        }
                        else if (splitLine[2] == "..")
                        {
                            currentLocation = currentLocation.PreviousDirectory;
                        }
                        else
                        {
                            currentLocation = currentLocation.Directories.First(x => x.Name == splitLine[2]);
                        }
                        currentCommand = CurrentCommand.ChangeDirectory;
                    }
                }
                else if (currentCommand == CurrentCommand.ListDirectory)
                {
                    if (splitLine[0] == "dir")
                    {
                        currentLocation.Directories.Add(new Directory(){ Name = splitLine[1], PreviousDirectory = currentLocation });
                    }
                    else
                    {
                        currentLocation.Files.Add(new File{ Name = splitLine[1], Size = long.Parse(splitLine[0])});
                    }
                }
            }

            var totalUnusedSpace = 70000000L - fileSystem.TotalFileSize;
            var totalSizeNeeded = 30000000L - totalUnusedSpace;
            var dirSize = new List<long>();
            TraverseDirectory(fileSystem);
            var minSize = dirSize.Min();


            Console.WriteLine("Current Directory To Delete Size: " + minSize);

            void TraverseDirectory(Directory theDirectory)
            {
                foreach (var dir in theDirectory.Directories)
                {
                    TraverseDirectory(dir);
                }

                if (theDirectory.TotalFileSize >= totalSizeNeeded)
                {
                    dirSize.Add(theDirectory.TotalFileSize);
                }
            }
        }
    }

    internal enum CurrentCommand
    {
        ChangeDirectory,
        ListDirectory
    }

    internal class Directory
    {
        public string Name { get; set; }
        public List<Directory> Directories { get; set; } = new List<Directory>();
        public List<File> Files { get; set; } = new List<File>();
        public Directory PreviousDirectory { get; set; }

        public long TotalFileSize
        {
            get
            {
                return Files.Select(x => x.Size).Sum() + Directories.Select(x => x.TotalFileSize).Sum();
            }
        }
    }

    internal class File
    {
        public string Name { get; set; }
        public long Size { get; set; }
    }
}
