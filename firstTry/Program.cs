using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;
using System.IO;

namespace firstTry
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int attempts = 6;
            Console.WriteLine(FiggleFonts.Standard.Render("Linguisto"));

            while (attempts > 0) 
            {
                int play = 0;

                Console.WriteLine("Do you want to try? yes/no.");
                string input3 = Console.ReadLine();

                if (input3 == "yes") //play = 1 app starts
                {
                    play = 1;
                    attempts --;
                }
                else if (input3 == "no") //play = 0 app quits
                    {
                    play = 0;
                    attempts = 0;
                    Console.WriteLine("Sorry to hear that.");
                }
                else //play = 2 app starts over
                {
                    Console.WriteLine("You probably typed it wrong.");
                    play = 2;
                    //Console.ReadLine();
                }

                if (play == 1)
                {
                    Console.WriteLine("Type any word");
                    string input1 = Console.ReadLine();
                    string word1 = input1.ToLower();

                    Console.WriteLine("Type any other word");
                    string input2 = Console.ReadLine();
                    string word2 = input2.ToLower();


                    string output1 = word1 + " " + word2;
                    DictionaryCheck(output1, word1, word2);

                    Console.WriteLine("You cast the spell");
                    Console.WriteLine(FiggleFonts.Standard.Render(output1));
                    //Console.WriteLine("You typed " + output1.Length + " characters.");
                    Console.WriteLine("You have " + attempts + " attempts left to defeat the enemy.");
                    //Console.ReadLine();
                }
                else if (play == 2)
                {
                    Console.WriteLine("Press enter to try again.");
                    Console.ReadLine();
                }
                
                else
                {
                    Console.WriteLine("Press enter to exit. Good bye.");
                    Console.ReadLine();
                }

            }
            //game over
            Console.WriteLine(FiggleFonts.Standard.Render("game over"));
            Console.WriteLine("Press enter to exit. Good bye.");
            Console.ReadLine();

        }
        static bool DictionaryCheck(string output1, string word1, string word2)
        {
            string WordsAlpha = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\dictionaries\\words_alpha.txt");
            //Console.WriteLine(output1);
            Console.WriteLine(word1);
            Console.WriteLine(word2);
            string[] words = File.ReadAllLines(WordsAlpha);
            //Console.WriteLine(words[]);
            int pos = Array.IndexOf(words, word1);
            if (pos > -1)
            {
                Console.WriteLine("Match found");
                return true;
            }
            return false;
        }
    }
}
