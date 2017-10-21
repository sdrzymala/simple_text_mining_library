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

        /// <summary>
        /// Specify the language of the text
        /// </summary>
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

        /// <summary>
        /// Remove stop words from text
        /// The list of the stop words will be choosen for a particular language defined in the class
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove special characters from input text
        /// When removeNumber set to true numbers will be deleted
        /// When removeNumber set to false number will not be deleted
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="removeNumbers"></param>
        /// <returns></returns>
        public string RemoveSpecialCharacters(string inputText, bool removeNumbers)
        {
            // remove urls
            string outputText = Regex.Replace(inputText, @"http[^\s]+", " ", RegexOptions.Compiled);

            // remove special characters
            if (!removeNumbers)
            {
                outputText = Regex.Replace(outputText, "[^a-zA-Z0-9 ]+", " ", RegexOptions.Compiled);
            }
            else
            {
                outputText = Regex.Replace(outputText, "[^a-zA-Z ]+", " ", RegexOptions.Compiled);
            }

            // clean spaces
            outputText = Regex.Replace(outputText, @"\s+", " ", RegexOptions.Compiled);

            return outputText.ToLower();
        }

        /// <summary>
        /// Remote N=1 gram list from text
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public List<string> N1GramAnalysis(string inputText)
        {
            return inputText.Split(' ').ToList();
        }
    }
}
