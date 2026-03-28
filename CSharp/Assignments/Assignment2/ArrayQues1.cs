using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class ArrayQues1
    {
        public static void Array_fun()
        {
            Console.WriteLine("Enter the size of the array : ");
            int sum=0,minv=int.MaxValue,maxv=int.MinValue,x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the values:{Eg: 1 2 3 4 5}");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < x; i++)
            {
                if (arr[i] > maxv) { maxv = arr[i]; }
                if(arr[i] < minv) {minv = arr[i]; }
                sum += arr[i];
            }
            Console.WriteLine($"1.Average value of array elements : {sum/x}");
            Console.WriteLine($"2.Maximum and Minimum Value in the array are: \nMax Value: {maxv} Min Value: {minv}");

        }
    }
}
