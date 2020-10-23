using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    class PopUpInfo
    {
        //int width, height;
        int xpos, ypos;
        string[] box;
        int length;
        IChoise choise;
        Style style;

        public PopUpInfo(string msg, Style new_style = Style.INFO)
        {
            string[] option = { "OK" };
            try{
                box = BoxGenerator.createBox(msg, option);
            }
            catch(Exception e)
            {
                box = BoxGenerator.createBox(e.Message, option);
                new_style = Style.ERROR;
            }

            xpos = (Constants.Width - box[0].Length) / 2;
            ypos = (Constants.Height - box.Length) / 2;
            length = box[0].Length;
            choise = new MultipleChoise(option, length, (Constants.Height - box.Length) / 2 + 3, xpos);

            this.style = new_style;
        }

        public void pop()
        {
            show_up();

            Console.Beep();

            Console.SetCursorPosition(Constants.Width / 2, ypos + box.Length - 2);

            choise.getAnswer();

            ConsoleGrapher.Clear();
        }

        private void show_up()
        {
            int currentLine = ypos;
            ConsoleColor prev = ConsoleColor.DarkGray;

            foreach (var line in box)
            {
                object_colour[] temp = new object_colour[1];


                switch (style)
                {
                    case Style.ERROR:
                        temp[0] = new object_colour(line, ConsoleColor.Red, ConsoleColor.White);
                        break;

                    case Style.INFO:
                        temp[0] = new object_colour(line);
                        break;
                        
                    case Style.RAINBOW:
                        temp[0] = new object_colour(line, ConsoleColor.Black, ++prev);
                        break;
                };
                
                ConsoleGrapher.RenderString(temp, length, currentLine, xpos);

                currentLine += 1;
            }
        }
    }
}
