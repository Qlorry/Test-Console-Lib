using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class PopUpMultipleChoise : IPopUp
    {
        IChoise choise;
        string[] box;
        ConsoleGrapher gh;
        int width, height;
        int xpos;
        int length;


        public PopUpMultipleChoise(string msg, ConsoleGrapher gh, string[] options)
        {
            this.gh = gh;

            box = BoxGenerator.createBox(msg, options);
            length = box[0].Length;

            width = Console.WindowWidth;
            height = Console.WindowHeight;

            xpos = (width - box[0].Length) / 2;

            choise = new MultipleChoise(gh, options, length, (height - box.Length) / 2 + 3, xpos);
        }

        public void pop()
        {
            int currentLine = (height - box.Length) / 2;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                gh.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }
            choise.getAnswer();

            Console.Clear();
        }
    }
}
