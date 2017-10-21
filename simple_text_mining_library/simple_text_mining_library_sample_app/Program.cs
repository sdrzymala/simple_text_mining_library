using simple_text_mining_library;
using simple_text_mining_library.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_text_mining_library_sample_app
{
    class Program
    {
        static void Main(string[] args)
        {

            string myTextToMine = File.ReadAllText(@"‪C:\test\books\12383.txt");

            MineText mineText = new MineText();
            mineText.textMiningLanguage = TextMiningLanguage.English;
            mineText.RemoveStopWordsFromText(myTextToMine);

        }
    }
}
