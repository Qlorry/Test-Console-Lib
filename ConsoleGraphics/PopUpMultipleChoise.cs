using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class PopUpMultipleChoise : IPopUp
    {
        IChoise choise;
        string[] box;
        int xpos, ypos;
        int length;


        public PopUpMultipleChoise(string msg, string[] options)
        {
            box = BoxGenerator.createBox(msg, options);
            length = box[0].Length;

            xpos = (Constants.Width - box[0].Length) / 2;
            ypos = (Constants.Height - box.Length) / 2;


            choise = new MultipleChoise(options, length, ypos + 3, xpos);
        }

        public int pop()
        {
            int res = -1;
            Console.Beep();

            int currentLine = ypos;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                ConsoleGrapher.RenderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }
            res = choise.getAnswer();

            ConsoleGrapher.Clear();
            return res;
        }
    }
}
