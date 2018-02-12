using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace SwearingIsFun.Library
{
    public class CloudUtility
    {
        public static readonly string SwearList = "phrases.txt";

        public static bool CheckForSwear(string sentance)
        {
            foreach (var swear in File.ReadAllLines(SwearList).ToList())
                foreach (var word in sentance.Split(' '))
                    if (word == swear) return true;
            return false;
        }
    }
}
