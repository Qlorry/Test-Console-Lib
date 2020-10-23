using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public static class Constants
    {
        private static int space  = 2;
        private static int width = Console.WindowWidth, heigth = Console.WindowHeight;

        public static int Space => space;
        public static int Width => width;
        public static int Height => heigth;


        public static void setConstrains(int new_width = -1, int new_height = -1)
        {
            width = new_width < 0 ? width : new_width;
            heigth = new_height < 0 ? heigth : new_height;
        }
    }


    public enum Style
    {
        INFO,
        ERROR,
        RAINBOW
    }
}
