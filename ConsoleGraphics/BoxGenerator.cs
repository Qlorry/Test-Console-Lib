using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGraphics
{
    public static class BoxGenerator
    {
        public static string[] createBox(string msg, string[] options)
        {
            int boxWidth;
            int space = 2; 
            int totalLength = space;

            foreach (var item in options)
            {
                totalLength += item.Length + space;
            }

            if (msg.Length + 2 * space > totalLength)
            {
                boxWidth = msg.Length + 2 * space;
                if (msg.Length % 2 != 0) boxWidth += 1;
            }
            else boxWidth = totalLength;

            string emptyLine = new string(' ', boxWidth);


            int firstEmpty = (boxWidth - msg.Length) / 2;
            string msgLine = new string(' ', firstEmpty) + msg;
            msgLine += new string(' ', boxWidth - msgLine.Length);


            return new string[]
            {
                emptyLine,
                msgLine,
                emptyLine,
                emptyLine,
                emptyLine
            };
        }
    }
}
