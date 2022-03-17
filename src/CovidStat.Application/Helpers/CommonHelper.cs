using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.Helpers
{
    public static class CommonHelper
    {
        public static char GetLetter()
        {
            Random _random = new Random();
            int num = _random.Next(0, 26);
            char let = (char)('a' + num);
            return let;
        }

        public static string GetLetters(int count = 1)
        {
            string letters = "";
            for (int a = 0; a < count; a++)
            {
                letters += GetLetter();
            }
            return letters;
        }
    }
}
