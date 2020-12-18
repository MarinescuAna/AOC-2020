using AOC.DaysClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Day11Process.Process();//no working part 2
            //Day16Process.Process();//no working part 2
            Day18Process.Process();
        }

      
        static void day11()
        {
            Day11 day11 = new Day11();
            day11.Part1();
            day11.Part2();//to solve...
        }

        static void day16()
        {
            Day16 day16 = new Day16();
            day16.Part1();
            day16.Part2();//no working..
        }
       
    }
}
