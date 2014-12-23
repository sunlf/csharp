using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpDEV.Stream
{
    public class StreamTest
    {
        public static void Stream1()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string str = "Steam!Hello world";
                byte[] readBuffer = null;
                byte[] buffer = null;
                if (ms.CanRead)
                {
                    buffer = Encoding.Default.GetBytes(str);
                    ms.Write(buffer, 0, 3);
                    Console.WriteLine("现在ms.Postion在第{0}位置", ms.Position + 1);
                    long newPostionInms = ms.Seek(3, SeekOrigin.Current);
                    Console.WriteLine("重定位后ms.Postion在第{0}位置", newPostionInms + 1);

                    if (newPostionInms < buffer.Length)
                    {
                        ms.Write(buffer, (int)newPostionInms, buffer.Length - (int)newPostionInms);
                    }

                    ms.Position = 0;

                    readBuffer = new byte[ms.Length];
                    int count = ms.CanRead ? ms.Read(readBuffer, 0, readBuffer.Length) : 0;

                    int charCount = Encoding.Default.GetCharCount(readBuffer, 0, count);

                    char[] readCharArr = new char[charCount];
                    Encoding.Default.GetDecoder().GetChars(readBuffer, 0, count, readCharArr, 0);
                    string resStr = new string(readCharArr);
                    Console.WriteLine(resStr);
                }
            }
        }

        public static void TextReaderTest()
        {
            StreamReader sr = new StreamReader();
        }
    }
}
