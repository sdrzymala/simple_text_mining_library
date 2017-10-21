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

            string filePath = Directory.GetFiles("C:/test/books/").Where(x=>x.Contains("12383")).First();
            string sampleInputText = File.ReadAllText(filePath);

            MineText mineText = new MineText();
            mineText.textMiningLanguage = TextMiningLanguage.English;

            string d = mineText.RemoveStopWordsFromText(sampleInputText);

        }
    }
}
