using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGraphics
{
    public static class Procutils {
        public static int getMaxLen(string msg, string[] options)
        {
            int result;
            int totalLength = Constants.Space;

            foreach (var item in options)
            {
                totalLength += item.Length + Constants.Space;
            }

            if (msg.Length + (2 * Constants.Space) > totalLength)
            {
                result = msg.Length + 2 * Constants.Space;
                if (msg.Length % 2 != 0) result += 1;
            }
            else result = totalLength;

            return result;
        }
    }

    public static class BoxGenerator
    {
        public static string[] createBox(string msg, string[] options)
        {
            //Find longest string
            int boxWidth = Procutils.getMaxLen(msg, options);

            if(boxWidth > Console.WindowWidth)
            {
                throw new Exception("Too big msg!!!");
            }

            //Line of ' '
            string emptyLine = new string(' ', boxWidth);

            //Line: Constants.Space + text + Constants.Space
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
