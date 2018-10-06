using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("Reading text file named: (" + args[0] + ")");
                String text = getFileContents(args[0]);
                Console.WriteLine("Word count: " + countWordsWithIteration(text));
            }
            else
            {
                Console.WriteLine("Please provide the text file's filepath as command line argument");
            }
            Console.WriteLine("Press any key to exit");
            var wait = Console.ReadLine();
        }

        static String getFileContents(String fileName) {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    String contents = reader.ReadToEnd();
                    return contents;
                }
            }
            catch (Exception e) {
                Console.WriteLine("There was a problem reading the file: ");
                Console.WriteLine(e.Message);
                return "";
            }
        }
        

        static int countWordsWithIteration(String text) {
            int count = 0;
            int i = 0;
            
            while (i < text.Length) {
                while (i < text.Length && !char.IsWhiteSpace(text[i])) {
                    i++;
                }
                count++;
                while (i < text.Length && char.IsWhiteSpace(text[i])) {
                    i++;
                }
            }
            
            return count;
        }
        static int countWordsWithSplit(String text) {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        
    }
}
