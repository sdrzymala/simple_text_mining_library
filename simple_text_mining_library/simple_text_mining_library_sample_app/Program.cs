using simple_text_mining_library;
using simple_text_mining_library.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace simple_text_mining_library_sample_app
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SampleBooks\10012.txt");
            string sampleInputText = File.ReadAllText(filePath);

            MineText mineText = new MineText();
            mineText.textMiningLanguage = TextMiningLanguage.English;

            string a = mineText.RemoveSpecialCharacters(sampleInputText, true);
            string b = mineText.RemoveSpecialCharacters(sampleInputText, false);
            string c = sampleInputText;

            string d = mineText.RemoveStopWordsFromText(a);

        }
    }
}
