using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class MultipleChoise : IChoise
    {
        string[] options;
        int X_Pos, Y_Pos;
        int length;
        ConsoleGrapher gh;

        public MultipleChoise(ConsoleGrapher gh, string[] newOptions, int length, int ypos = -1, int xpos = -1)
        {
            this.options = new string[newOptions.Length];
            newOptions.CopyTo(this.options, 0);
            if (ypos == -1)
            {
                X_Pos = Console.CursorTop;
            }
            else X_Pos = ypos;
            if (xpos == -1)
            {
                Y_Pos = 0;
            }
            else Y_Pos = xpos;

            this.length = length;
            this.gh = gh;
        }

        public int getAnswer()
        {
            object_colour[] data = new object_colour[options.Length];
            for(int i = 0; i < options.Length; i++) { data[i] = new object_colour(ConsoleColor.Black, ConsoleColor.Gray); }

            int selectedElement = 0;

            data[0].foreground = ConsoleColor.Magenta;
            data[0].background = ConsoleColor.Gray;

            for (int i = 0; i < data.Length; i++) {
                data[i].str = options[i];
            }

            gh.renderString(data, length, X_Pos, Y_Pos);
            Console.Beep();

            while (true){
                ConsoleKeyInfo keyPressed = Console.ReadKey(false);

                if (keyPressed.Key == ConsoleKey.Enter) break;

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (selectedElement == 0) continue;
                    data[selectedElement].foreground = ConsoleColor.Black;
                    data[selectedElement - 1].foreground = ConsoleColor.Magenta;
                    selectedElement -= 1;

                    gh.renderString(data, length, X_Pos, Y_Pos);
                    continue;
                }
                
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (selectedElement == options.Length - 1) continue;
                    data[selectedElement].foreground = ConsoleColor.Black;
                    data[selectedElement + 1].foreground = ConsoleColor.Magenta;
                    selectedElement += 1;

                    gh.renderString(data, length, X_Pos, Y_Pos);
                    continue;
                }
            }
            return selectedElement;
        }
    }
}
