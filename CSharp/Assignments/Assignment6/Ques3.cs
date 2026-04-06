using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Ques3
    {
        public static void Filelen()
        {
            string path = @"C:\Users\jayavardhinim\OneDrive - Infinite Computer Solutions (India) Limited\Desktop\Training\CSharp\Assignments\Assignment6\Questions.bin";
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write("1. Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. \r\n\r\nCreate an Indexer of Books Object to store 5 books in a class called BookShelf. Using the indexer method assign values to the books and display the same.\r\n\r\nHint(use Aggregation/composition)\r\n\r\n2. Write a program in C# Sharp to create a file and write an array of strings to the file. Also Read from the file\r\n\r\n3. Write a program in C# Sharp to count the number of lines in a file.");
            }

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine("Number of lines: " + lines.Length);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
