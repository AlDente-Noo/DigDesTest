using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t','\n', '?', '!', '[', ']', '-', '@',
            '1','2','3', '4', '5', '6', '7', '8', '9', '0', '(', ')', '"','/', '*', ';'};
            string FilePath = @"C:\Users\tymab\source\repos\Test\Test\War.txt";
            Dictionary<string, int> result =  CalcAllWords(FilePath, delimiterChars);
            Dictionary<string, int>  sortedResult =
                result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            File.WriteAllLines("result.txt",sortedResult.Select(x => x.Key + " " + x.Value ).ToArray());
            return;
        }
        static Dictionary<string, int> CalcAllWords(string FilePath, char[] delimiterChars)
        {
            Dictionary<string,int> words = new Dictionary<string, int>();
            foreach (string line in File.ReadAllLines(FilePath))
            {
                foreach(string token in line.Split(delimiterChars))
                {
                    int n = 0;
                    string newToken = token.ToLower();
                    if (newToken == "")
                        continue;
                    try
                    {
                        words.Add(newToken, n);
                    } catch(Exception e)
                    {
                        words[newToken] += 1;
                        continue;
                    }
                    words[newToken] = n + 1;
                }
            }
            return words;
        }
    }

}
