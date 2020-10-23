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
        
        public object_colour(string text, ConsoleColor foregr, ConsoleColor backgr)
        {
            str = text;
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

        public static void Init(int width, int heigth, string[] newMask = null, object[] startValues = null)
        {
            //set console sizes, min w = 20 min h = 6
            Constants.setConstrains(width < 20 ? 20 : width, heigth < 6 ? 6 : heigth);
            Console.BufferWidth = Console.WindowWidth = Constants.Width;
            Console.BufferHeight = Console.WindowHeight = Constants.Height;


            //set mask if given
            if (newMask != null)
            {
                SetMask(newMask);

                //render if values given
                if (startValues != null)
                {
                    values = new object[startValues.Length];
                    startValues.CopyTo(values, 0);

                    Render(values);
                }
            }
            else printHello();
        }

        private static void printHello()
        {
            PopUpInfo Info = new PopUpInfo("Hello!!!", Style.RAINBOW);
            Info.pop();
        }

        public static void Render(object[] new_values = null)
        {
            Clear();
            try
            {
                render(new_values);
            }
            catch(Exception e)
            {
                PopUpInfo Info = new PopUpInfo(e.Message, Style.ERROR);
                Info.pop();
            }
        }

        private static void render(object[] new_values = null)
        {
            if (new_values != null)
            {
                values = new object[new_values.Length];
                new_values.CopyTo(values, 0);
            }

            if (mask == null) throw new Exception("No mask!!");
            if (values == null) throw new Exception("No values!!");
            
            Console.WriteLine(compileMask(), values);
        }

        public static void RenderString(object_colour[] object_s, int length, int ypos = -1, int xpos = -1) //space -1 for whole screen
        {
            if (object_s == null)
            {
                Console.WriteLine("Rendering Once Error");
                return;
            }

            if (ypos > Constants.Height || xpos > Constants.Width)
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


            if(length == -1)
            {
                length = Constants.Width;
            }


            Console.SetCursorPosition(xpos, ypos);

            //Console.BackgroundColor = ConsoleColor.White;
            //Console.Write(new string(' ', spaces));

            for (int i = 0; i < object_s.Length - 1; i++)
            {
                Console.BackgroundColor = object_s[i].background;
                Console.ForegroundColor = object_s[i].foreground;
                Console.Write(object_s[i].str);

                Console.ResetColor();
                //Console.BackgroundColor = ConsoleColor.White;
                //Console.Write(new string(' ', spaces));
            }

            Console.BackgroundColor = object_s[object_s.Length-1].background;
            Console.ForegroundColor = object_s[object_s.Length - 1].foreground;
            Console.Write(object_s[object_s.Length - 1].str);

            Console.ResetColor();
        }

        public static void SetMask(string[] newMask)
        {
            if(newMask == null)
            {
                mask = null;
                return;
            }

            mask = new string[newMask.Length];
            newMask.CopyTo(mask, 0);
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

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
