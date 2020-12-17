using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC.DaysClass
{
    public class Day16
    {
        private static StreamReader file = new StreamReader(Constants.Path + "In16.txt");
        private Dictionary<string, List<(int, int)>> ranges = new Dictionary<string, List<(int, int)>>();
        private List<int> myTicket = new List<int>();
        private List<List<int>> nearbyTickets = new List<List<int>>();
        public Day16()
        {
            ReadInput();
        }

        private void ReadInput()
        {

            var line = string.Empty;
            var tags = new List<string>();

            while (!string.IsNullOrEmpty((line = file.ReadLine())))
            {
                var text = line.Split(':');
                tags.Add(text[0]);
                var splitOr = text[1].Split("or");
                var list = new List<(int, int)> {
                    (int.Parse(splitOr[0].Split('-')[0]), int.Parse(splitOr[0].Split('-')[1])),
                    (int.Parse(splitOr[1].Split('-')[0]), int.Parse(splitOr[1].Split('-')[1]))
                };
                ranges.Add(text[0], list);
            }
            while (!string.IsNullOrEmpty((line = file.ReadLine())))
            {
                var splitComma = line.Split(',');
                foreach (var number in splitComma)
                {
                    myTicket.Add(int.Parse(number));
                }
            }
            while (!string.IsNullOrEmpty((line = file.ReadLine())))
            {
                var splitComma = line.Split(',');
                var list = new List<int>();
                foreach (var number in splitComma)
                {
                    list.Add(int.Parse(number));
                }
                nearbyTickets.Add(list);
            }

        }
        private List<int> ChooseNumbers(List<(int, int)> range)
        {
            var lists = new List<int>();

            for (var i = 0; i < nearbyTickets.Count; i++)
            {
                if (nearbyTickets[i].Where(u => SearchIn(u, range)).Count() == nearbyTickets[i].Count)
                {
                    lists.Add(i);
                }
            }
            return lists;
        }
        private bool IsPartOfRange(int number) =>
            ranges.Where(u => SearchIn(number, u.Value)).Count() != 0;
        private bool SearchIn(int numberToSearch, List<(int, int)> list) =>
            list.FindIndex(u => (numberToSearch >= u.Item1 && numberToSearch <= u.Item2)) != -1;
        public void Part1()
        {
            var sum = 0L;
            foreach (var list in nearbyTickets)
            {
                sum += list.Where(u => !IsPartOfRange(u)).Sum();
            }
            Console.WriteLine("Day 16: Ticket Translation {0} (part1)", sum);
        }
        public void Part2()
        {
            long prod = 1;
            var freq = new int[nearbyTickets.Count + 1];

            var validTickets = new List<(string, List<int>)>();

            foreach (var range in ranges)
            {
                validTickets.Add((range.Key, ChooseNumbers(range.Value)));
            }
            validTickets = validTickets.OrderByDescending(u => u.Item2.Count).ToList();
            
            var times = new int[21];

            for (var ticket = 0; ticket < validTickets.Count; ticket++)
            {
               // Console.WriteLine($"{myTicket[matchingFields.First().Fields]} => {firstMatch.Fields.First()}");
                Console.WriteLine(ticket+":"+myTicket[ticket] + " => " + validTickets[ticket].Item2.Count+" - "+ validTickets[ticket].Item1);
            }

            Console.WriteLine("Day 16: Ticket Translation {0} (part2)", prod);
        }
    }

}
