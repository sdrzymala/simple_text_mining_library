using simple_text_mining_library.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace simple_text_mining_library
{
    public class MineText
    {
        TextMiningLanguage currentTextMiningLanguage;
        string currentBasicStopWordsFilePath;

        public TextMiningLanguage textMiningLanguage
        {
            get
            {
                return currentTextMiningLanguage;
            }
            set
            {
                currentTextMiningLanguage = value;

                if (currentTextMiningLanguage == TextMiningLanguage.English)
                {
                    currentBasicStopWordsFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dictionaries\stopwords_basic_en.txt");
                }
                else if (currentTextMiningLanguage == TextMiningLanguage.Polish)
                {
                    currentBasicStopWordsFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dictionaries\stopwords_basic_en.txt");
                }
            }
        }

        public string RemoveStopWordsFromText(string inputText)
        {
            List<string> allStopWords = File.ReadAllLines(currentBasicStopWordsFilePath).ToList().Where(x=> !x.Contains("#")).ToList();
            StringBuilder outputText = new StringBuilder();

            foreach (string word in inputText.Split(' '))
            {
                if (!allStopWords.Contains(word))
                {
                    outputText.Append(word).Append(" ");
                }
            }

            return outputText.ToString().TrimEnd();
        }
    }
}
