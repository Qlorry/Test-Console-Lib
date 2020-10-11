using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class PopUpYesOrNo
    {
        IChoise choise;
        string[] box;
        int width, height;
        int xpos, ypos;
        int length;

        public PopUpYesOrNo(string msg)
        {
            string[] options = { "Yes", "No" };
            box = BoxGenerator.createBox(msg, options);
            length = box[0].Length;

            width = Console.WindowWidth;
            height = Console.WindowHeight;

            xpos = (width - box[0].Length) / 2;
            ypos = (height - box.Length) / 2;


            choise = new MultipleChoise(options, length, (height - box.Length) / 2 + 3, xpos);
        }

        public bool pop()
        {
            Console.Beep();

            int currentLine = ypos;
            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];
                temp[0] = new object_colour(line);

                ConsoleGrapher.renderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }
            bool res;
            if (choise.getAnswer() == 0) res = true;
            else res = false;

            ConsoleGrapher.clear();

            return res;
        }
    }
}
