using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    class PopUpInfo
    {
        int width, height;
        int xpos;
        string[] box;
        int length;
        IChoise choise;

        public PopUpInfo(string msg)
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;

            string[] option = { "OK" };
            box = BoxGenerator.createBox(msg, option);

            xpos = (width - box[0].Length) / 2;
            length = box[0].Length;
            choise = new MultipleChoise(option, length, (height - box.Length) / 2 + 3, xpos);
        }

        public void pop()
        {
            int currentLine = (height - box.Length) / 2;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                ConsoleGrapher.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }

            Console.Beep();

            Console.SetCursorPosition(width / 2, (height - box.Length) / 2 + box.Length - 2);

            choise.getAnswer();

            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;

            //Console.SetCursorPosition((width - msg.Length) / 2, (height - 1) / 2);
            //for (int i = 0; i < box.Length; i++)
            //{
            //    Console.SetCursorPosition((width - box[i].Length) / 2, (height - box.Length) / 2 + i);
            //    if (i == box.Length - 2)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Magenta;
            //        Console.BackgroundColor = ConsoleColor.Gray;
            //        Console.WriteLine(box[i]);
            //        Console.ForegroundColor = ConsoleColor.Black;
            //        Console.BackgroundColor = ConsoleColor.White;
            //    }
            //    else Console.WriteLine(box[i]);
            //}



            Console.Clear();
        }
    }
}
