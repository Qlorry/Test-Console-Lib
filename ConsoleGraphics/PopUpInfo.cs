using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    class PopUpInfo
    {
        int width, height;
        int xpos, ypos;
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
            ypos = (height - box.Length) / 2;
            length = box[0].Length;
            choise = new MultipleChoise(option, length, (height - box.Length) / 2 + 3, xpos);
        }

        public void pop()
        {
            int currentLine = ypos;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                ConsoleGrapher.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }

            Console.Beep();

            Console.SetCursorPosition(width / 2, ypos + box.Length - 2);

            choise.getAnswer();

            ConsoleGrapher.clear();
        }
    }
}
