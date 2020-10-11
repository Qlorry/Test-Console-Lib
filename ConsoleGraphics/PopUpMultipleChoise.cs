using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class PopUpMultipleChoise : IPopUp
    {
        IChoise choise;
        string[] box;
        int width, height;
        int xpos;
        int length;


        public PopUpMultipleChoise(string msg, string[] options)
        {
            box = BoxGenerator.createBox(msg, options);
            length = box[0].Length;

            width = Console.WindowWidth;
            height = Console.WindowHeight;

            xpos = (width - box[0].Length) / 2;

            choise = new MultipleChoise(options, length, (height - box.Length) / 2 + 3, xpos);
        }

        public void pop()
        {
            Console.Beep();

            int currentLine = (height - box.Length) / 2;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                ConsoleGrapher.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }
            choise.getAnswer();

            Console.Clear();
        }
    }
}
