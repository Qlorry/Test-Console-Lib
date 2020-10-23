using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class MultipleChoise : IChoise
    {
        string[] options;
        int X_Pos, Y_Pos;
        int length;
        object_colour[] data;

        public MultipleChoise(string[] newOptions, int length, int ypos = -1, int xpos = -1)
        {
            options = new string[newOptions.Length];
            newOptions.CopyTo(options, 0);
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
        }


        private void genString()
        {
            int totalLength = 0;
            int totalSize;
            foreach (var item in options)
            {
                totalLength += item.Length;
            }

            int spaces = (length - totalLength) / (options.Length + 1); // 2 paddings + (options.Len - 1) * spaces
            totalSize = ((length - totalLength) / spaces) + options.Length;


            data = new object_colour[totalSize];
            
            for (int i = 0, j = 0; i < options.Length;) {
                data[j++] = new object_colour(new string(' ', spaces), ConsoleColor.Black, ConsoleColor.Gray);
                data[j++] = new object_colour(options[i++], ConsoleColor.Black, ConsoleColor.Gray);
            }
            data[data.Length-1] = new object_colour(new string(' ', spaces), ConsoleColor.Black, ConsoleColor.Gray);
        }

        public int getAnswer()
        {
            genString();
            int selectedElement = 1;

            data[selectedElement].foreground = ConsoleColor.Magenta;
            data[selectedElement].background = ConsoleColor.Gray;

            ConsoleGrapher.RenderString(data, length, X_Pos, Y_Pos);

            while (true){
                ConsoleKeyInfo keyPressed = Console.ReadKey(false);

                if (keyPressed.Key == ConsoleKey.Enter) break;

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (selectedElement == 1) continue;
                    data[selectedElement].foreground = ConsoleColor.Black;
                    data[selectedElement - 2].foreground = ConsoleColor.Magenta;
                    selectedElement -= 2;

                    ConsoleGrapher.RenderString(data, length, X_Pos, Y_Pos);
                    continue;
                }
                
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (selectedElement == data.Length - 2) continue;
                    data[selectedElement].foreground = ConsoleColor.Black;
                    data[selectedElement + 2].foreground = ConsoleColor.Magenta;
                    selectedElement += 2;

                    ConsoleGrapher.RenderString(data, length, X_Pos, Y_Pos);
                    continue;
                }
            }

            return (selectedElement - 1) / 2;
        }
    }
}
