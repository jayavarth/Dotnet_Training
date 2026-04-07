using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. \r\n\r\nCreate an Indexer of Books Object to store 5 books in a class called BookShelf. Using the indexer method assign values to the books and display the same.\r\n\r\nHint(use Aggregation/composition)");
            Ques1.Bookindex();
            Console.WriteLine("--------\n2. Write a program in C# Sharp to create a file and write an array of strings to the file. Also Read from the file");
            Ques2.StringArray();
            Console.WriteLine("--------\n3. Write a program in C# Sharp to count the number of lines in a file.");
            Ques3.Filelen();
        }
    }
}
