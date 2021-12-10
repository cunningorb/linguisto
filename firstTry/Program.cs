using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;
using System.IO;

namespace firstTry
{
    class playerTry
	{
        public string Guess { get; set; }
        //public string asdfasdf { get; set; }
        //public string asdfaasdfsdf { get; set; }
        //player types word, feed into class and it will "construct" instance of object
        //nothing
	}
    
    class Program
    {
        static int jarJarBinks (string attempt)
                    {
                        //attempt is string
                        //If first word is good enough you get to type second word?
                        return attempt.Length *3;
                    }

        static void Main(string[] args)
        {
            int attempts = 6;
            string word1 = default;
            string word2 = default;
            int dragonHealth = 30;

            Console.WriteLine(FiggleFonts.Standard.Render("Linguisto"));
            
            while (attempts > 0 && dragonHealth > 0)
            {
                int play = 0;
                
                playerTry firstTry = new playerTry();
                firstTry.Guess = Console.ReadLine();
                Console.WriteLine(firstTry.Guess);

                Console.WriteLine(jarJarBinks("bloop bleep blorp"));
                Console.WriteLine("Do you want to try? Type yes/no.");
                string input3 = Console.ReadLine();

                if (input3 == "yes") //play = 1 app starts
                {
                    play = 1;
                    attempts--;
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
                    playerInput1(ref word1);
                    playerInput2(ref word2);
                    DictionaryCheck(word1, word2);

                    string output1 = word1 + " " + word2;
                    string output2 = word1 + word2;
                    //int spellStrength = 0;
                    //bool spell1 = false;
                    //bool spell2 = false;
                    //bool spell3 = false;

                    if (word1.Length > 3)
                    {
                        dragonHealth -= 10;
                        //spell1 = true;
                        Console.WriteLine("You cast a poor spell");
                        Console.WriteLine(FiggleFonts.Standard.Render(output1));
                    }
                    else if (word2.Length < 5)
                    {
                        dragonHealth -= 15;
                        //spell2 = true;
                        Console.WriteLine("You cast a good spell");
                        Console.WriteLine(FiggleFonts.Standard.Render(output1));
                    }
                    else if (output2.Length ==7)
                    {
                        dragonHealth -= 29;
                        //spell3 = true;
                        Console.WriteLine("You cast a great spell");
                        Console.WriteLine(FiggleFonts.Standard.Render(output1));
                    }

                

                    Console.WriteLine("You typed " + output2.Length + " characters. " + output1);
                    Console.WriteLine("You have " + attempts + " attempts left to defeat the enemy.");
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
            //You win
            if (dragonHealth < 1 && attempts > 0)
            {
                Console.WriteLine("you defeated dragon");
                Console.WriteLine(FiggleFonts.Standard.Render("you win"));
                Console.ReadLine();
            }

            //game over
            else
            {
                Console.WriteLine(FiggleFonts.Standard.Render("game over"));
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
            

        }
        static void playerInput1(ref string word1)//validates only characters typed first word
        {
            bool check1 = false;
            while (check1 == false)
            {
                Console.WriteLine("Type any word");
                string input1 = Console.ReadLine();
            
                    if (input1.All(char.IsLetter))
                    {
                        check1 = true;
                        word1 = input1.ToLower();
                        break;
                    }
                    else
                    {
                        check1 = false;
                    }
                    if (check1 == false)
                    {
                        Console.WriteLine("Enter Valid Value");
                    }
            }
            
        }
        static void playerInput2(ref string word2)//validates only characters typed second word
        {
            bool check2 = false;
            
            while (check2 == false)
            {
                Console.WriteLine("Type another word");
                string input2 = Console.ReadLine();

                    if (input2.All(char.IsLetter))
                    {
                        check2 = true;
                        word2 = input2.ToLower();
                        break;
                    }
                    else
                    {
                        check2 = false;
                    }
                    if (check2 == false)
                    {
                        Console.WriteLine("That wasn't a valid response.");
                    }
            }
            

        }
        static bool DictionaryCheck(string word1, string word2) //returns true if both words found
        {
            string WordsAlpha = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\dictionaries\\words_alpha.txt");
            string[] words = File.ReadAllLines(WordsAlpha);

            int word1Check = Array.IndexOf(words, word1);
            int word2Check = Array.IndexOf(words, word2);

            if (word1Check > -1)
            {
                Console.WriteLine("Match found");
                if (word2Check > -1)
                {
                    Console.WriteLine("2nd match found");
                    return true;
                }
            }
            return false;
        }
    }
}