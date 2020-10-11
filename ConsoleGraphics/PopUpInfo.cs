using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    class PopUpInfo
    {
        int width, height;
        ConsoleGrapher gh;
        int xpos;
        string[] box;
        int length;


        public PopUpInfo(ConsoleGrapher gh, string msg)
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            this.gh = gh;

            string[] option = { "OK" };
            box = BoxGenerator.createBox(msg, option);

            length = box[0].Length;
        }

        public void pop()
        {

            xpos = (width - box[0].Length) / 2;


            int currentLine = (height - box.Length) / 2;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                gh.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Console.SetCursorPosition((width - msg.Length) / 2, (height - 1) / 2);
            for (int i = 0; i < box.Length; i++)
            {
                Console.SetCursorPosition((width - box[i].Length) / 2, (height - box.Length) / 2 + i);
                if (i == box.Length - 2)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine(box[i]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else Console.WriteLine(box[i]);
            }

            Console.Beep();

            Console.ResetColor();

            Console.SetCursorPosition(width / 2, (height - box.Length) / 2 + box.Length - 2);

            while (Console.ReadKey().Key != ConsoleKey.Enter){}
            Console.Clear();
        }
    }
}
