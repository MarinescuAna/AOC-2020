using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC.DaysClass
{
    public class Day16
    {
        private static StreamReader file = new StreamReader(@"C:\Users\marin\OneDrive\Documente\GitHub\AOC-2020\DaysText\In16.txt");
        private int[] allNumbers = new int[1000];
        private int contor = 0;
        public Day16()
        {
            ReadInput();
        }

        private void ReadInput()
        {
            var line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                allNumbers[contor++] = Int32.Parse(line);
            }
        }
        public void Part1()
        {

            //Console.WriteLine("Day 16: Report Repair {0} (part2)", );
        }
        public void Part2()
        {
            
            //Console.WriteLine("Day 16: Report Repair {0} (part2)", );
        }
    }

}
