using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment_3
{
    internal class Ques2
    {
        static void Main()
        {
            FileStream fs = new FileStream(@"C:\Users\jayavardhinim\OneDrive - Infinite Computer Solutions (India) Limited\Desktop\Training\CSharp\Assessments\Csharp_Assessment_3\Ques2.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            Console.WriteLine("Enter a string:");
            string str = Console.ReadLine();

            sw.WriteLine(str);
            sw.Close();
            fs.Close();
            Console.WriteLine("Text Appended");
        }
    }
}
