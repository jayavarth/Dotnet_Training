using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class ArrayQues3
    {
        public static void CopyArray()
        {
            int[] arr = { 1, 2, 3, 4 };
            int[] arr1 = new int[arr.Length];

            for(int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr[i];
            }
            Console.WriteLine("Copied Array:");
            foreach(int x in arr1)
            {
                Console.WriteLine(x+" ");
            }
        }
    }
}
