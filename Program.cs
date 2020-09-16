using System;

namespace IBB_Changing_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            ConsoleKeyInfo continueOrExit;

        Begin:

            Console.Write("Bir cümle giriniz: ");
            userInput = Console.ReadLine();

            if (userInput.Length == 0)
                goto Begin;

            string[] splitedSentence = sentenceSpliter(userInput);

            splitedSentence = editWords(splitedSentence);

            makeSentence(splitedSentence);

        End:

            Console.Write("Devam etmek için 1'e, çıkmak için 0'a basınız.");
            continueOrExit = Console.ReadKey(true);
            switch (continueOrExit.Key)
            {
                case ConsoleKey.D0:
                    Console.WriteLine();
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine();
                    goto Begin;
                default:
                    Console.WriteLine();
                    goto End;
            }

        }

        private static void makeSentence(string[] splitedSentence)
        {
            char[] letters = { 'A', 'B', 'C' };
            string FinalSentence = new string(letters);
            FinalSentence = FinalSentence.Remove(0);

            /*for (int a = 0; a < splitedSentence.Length; a++)
            {
                Console.Write(splitedSentence[a]);
            }*/

            for (int i = 0; i < splitedSentence.Length; i++)
            {
                if (i != splitedSentence.Length - 1)
                    FinalSentence = FinalSentence.Insert(FinalSentence.Length, splitedSentence[i] + " ");
                else
                    FinalSentence = FinalSentence.Insert(FinalSentence.Length, splitedSentence[i]);
            }
            Console.WriteLine("Girdiğiniz cümle: {0}", FinalSentence);
        }

        private static string[] editWords(string[] splitedSentence)
        {
            for (int i = 0; i < splitedSentence.Length; i++)
            {
                splitedSentence[i] = splitedSentence[i].ToLower();

                char[] lettersOfWord = splitedSentence[i].ToCharArray();

                splitedSentence[i] = splitedSentence[i].Remove(0);

                lettersOfWord[0] = Convert.ToChar(Convert.ToString(lettersOfWord[0]).ToUpper());
                lettersOfWord[lettersOfWord.Length - 1] = Convert.ToChar(Convert.ToString(lettersOfWord[lettersOfWord.Length - 1]).ToUpper());

                for (int j = 0; j < lettersOfWord.Length; j++)
                {
                    splitedSentence[i] = splitedSentence[i].Insert(j, lettersOfWord[j].ToString());
                }
            }

            return splitedSentence;
        }

        private static string[] sentenceSpliter(string userInput)
        {
            string[] splitedSentence = userInput.Split(' ');
            return splitedSentence;
        }
    }
}
