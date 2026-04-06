using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Ques2
    {
        public static void WriteBinary()
        {
            string[] val = { "Blue", "Red", "Green", "Orange" };
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\Users\jayavardhinim\OneDrive - Infinite Computer Solutions (India) Limited\Desktop\Training\CSharp\Assignments\Assignment6\StringArray.bin", FileMode.Create)))
            {
                writer.Write(val.Length);

                foreach(string str in val)
                {
                    writer.Write(str);
                }
            }
        }

        public static void ReadBinary()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("C:\\Users\\jayavardhinim\\OneDrive - Infinite Computer Solutions (India) Limited\\Desktop\\Training\\CSharp\\Assignments\\Assignment6\\StringArray.bin", FileMode.Open)))
            {
                int length=reader.ReadInt32();

                for(int i = 0; i < length; i++)
                {
                    string str= reader.ReadString();
                    Console.WriteLine(str);
                }
            }
        }
        public static void StringArray()
        {
            WriteBinary();
            ReadBinary();
        }
    }
}
