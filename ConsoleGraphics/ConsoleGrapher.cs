using System;
using System.Collections.Generic;

namespace ConsoleGraphics
{
    public class object_colour
    {
        public String str;
        public ConsoleColor foreground;
        public ConsoleColor background;

        public object_colour(ConsoleColor foregr, ConsoleColor backgr)
        {
            str = "";
            foreground = foregr;
            background = backgr;
        }

        public object_colour(string text)
        {
            str = text;
            foreground = ConsoleColor.Black;
            background = ConsoleColor.White;
        }
    }

    public static class ConsoleGrapher
    {
        static string[] mask;
        static object[] values;

        static int width, heigth;

        public static void init(int width, int heigth, string[] newMask, object[] startValues = null)
        {
            Console.BufferWidth = Console.WindowWidth = width;
            Console.BufferHeight = Console.WindowHeight = heigth;


            ConsoleGrapher.width = width;
            ConsoleGrapher.heigth = heigth;

            setMask(newMask);

            if (startValues != null)
            {
                values = new object[startValues.Length];
                startValues.CopyTo(values, 0);

                render(values);
            }
            else printHello();
        }

        private static void printHello()
        {
            PopUpInfo Info = new PopUpInfo("Hello!!!");
            Info.pop();
            render();
        }

        public static void render(object[] new_values = null, int pos = 0)
        {
            //try
            //{
            if (new_values != null)
            {
                values = new object[new_values.Length];
                new_values.CopyTo(values, 0);
            }

            if (mask == null) return;

            if (values != null)
            {
                Console.WriteLine(compileMask(), values);
            }
            else Console.WriteLine("Rendering Error");

            //}
            //catch
            //{
            //    Console.WriteLine("Rendering Error");
            //}
        }

        public static void renderString(object_colour[] object_s, int length, int ypos = -1, int xpos = -1) //space -1 for whole screen
        {
            if (object_s == null)
            {
                Console.WriteLine("Rendering Once Error");
                return;
            }

            if (ypos > heigth || xpos > width)
            {
                Console.WriteLine("Rendering Once Error");
                return;
            }

            if (ypos == -1)
            {
                ypos = 0;
            }
            if (xpos == -1)
            {
                xpos = 0;
            }

            int totalLength = 0;
            foreach (var item in object_s)
            {
                totalLength += item.str.Length;
            }

            if(length == -1)
            {
                length = width;
            }

            int spaces = (length - totalLength) / (object_s.Length + 1); // 2 paddings + object_s.Len - 1 spaces

            Console.SetCursorPosition(xpos, ypos);

            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(new string(' ', spaces));

            for (int i = 0; i < object_s.Length - 1; i++)
            {
                Console.BackgroundColor = object_s[i].background;
                Console.ForegroundColor = object_s[i].foreground;
                Console.Write(object_s[i].str);

                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(new string(' ', spaces));
            }

            Console.BackgroundColor = object_s[object_s.Length-1].background;
            Console.ForegroundColor = object_s[object_s.Length - 1].foreground;
            Console.Write(object_s[object_s.Length - 1].str);

            Console.ResetColor();
        }

        public static void setMask(string[] newMask)
        {
            if(newMask == null)
            {
                ConsoleGrapher.mask = null;
                return;
            }

            ConsoleGrapher.mask = new string[newMask.Length];
            newMask.CopyTo(ConsoleGrapher.mask, 0);
        }

        private static string compileMask()
        {
            string res = "";
            if(mask == null) { return res; }

            foreach(string line in mask)
            {
                res += line;
            }

            return res;
        }

        public static void clear()
        {
            Console.Clear();
        }

    }


}
