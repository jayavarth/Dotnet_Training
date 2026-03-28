using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class ArrayQues2
    {
        public static void Marks()
        {
            int[] marks=new int[10];
            int s = 0;
            Console.WriteLine("Enter 10 marks");
            for(int i = 0; i < 10; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
                s += marks[i];
            }
            double avg = s / 10.0;
            int min = marks[0], max = marks[0];
            for(int i = 1; i < 10; i++)
            {
                if (marks[i]<min)min= marks[i];
                if(marks[i]>max)max= marks[i];
            }

            for(int i = 0; i < 10; i++)
            {
                for(int j = i + 1; j < 10; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }
            Console.WriteLine($"Total:{s}\nAverage:{avg}\nMinimum:{min}\nMaximum:{max}");

            Console.WriteLine("Ascending order :");
            foreach(int m in marks)
            {
                Console.WriteLine(m+" ");
            }
            Console.WriteLine("Descending order :");
            for(int i = 9; i >= 0; i--)
            {
                Console.WriteLine(marks[i]+" ");
            }
        }
    }
}
