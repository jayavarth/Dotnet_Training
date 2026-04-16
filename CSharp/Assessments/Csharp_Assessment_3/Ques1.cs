using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment_3
{
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int sum = 0;
            Console.WriteLine("Enter the scores:");

            for (int i = 0; i < no_of_matches; i++)
            {
                int score = int.Parse(Console.ReadLine());
                sum += score;
            }
            double avg = (double)sum/no_of_matches;

            Console.WriteLine($"Number of matches:{no_of_matches}");
            Console.WriteLine($"Total score:{sum}");
            Console.WriteLine($"Average score:{avg}");
        }
    }
    internal class Ques1
    {
        public static void Main()
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter number of matches: ");
            int matches = int.Parse(Console.ReadLine());
            team.Pointscalculation(matches);
            Console.ReadLine();
        }
    }
}