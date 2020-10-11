using System;
using System.Security.Cryptography;
using ConsoleGraphics;

namespace Test_Console_Lib
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGrapher.init(60, 20, null);

            string[] mask = {"____________________\n",
                             "{16,2} |{0,3}|{1,3}|{2,3}|{3,3}|\n",
                             "---|---|---|---|---|\n",
                             "{17,2} |{4,3}|{5,3}|{6,3}|{7,3}|\n",
                             "---|---|---|---|---|\n",
                             "{18,2} |{8,3}|{9,3}|{10,3}|{11,3}|\n",
                             "---|---|---|---|---|\n",
                             "{19,2} |{12,3}|{13,3}|{14,3}|{15,3}|\n",
                             "---|---|---|---|---|\n",
                             "   |{20,2} |{21,2} |{22,2} |{23,2} |\n\n" 
            };
            object[] data = new object[]
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                13, 14, 15, "x",
                "A", "B", "C", "D",
                1, 2, 3, 4
            };

            ConsoleGrapher.setMask(mask);
            //gh.setMaskInCenter();
            ConsoleGrapher.render(data);

            string[] variants = { "Ok", "NOT OK", "OKOK" };



            MultipleChoise choise2 = new MultipleChoise(variants, -1);
            choise2.getAnswer();

            PopUpMultipleChoise choise = new PopUpMultipleChoise("????????", variants);
            choise.pop();

            PopUpYesOrNo choise3 = new PopUpYesOrNo("??");
            choise3.pop();

            ConsoleGrapher.render();
        }
    }
}