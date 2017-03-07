using System;

namespace CountWord
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Enter the String");
            string sentences=Console.ReadLine();
            string[] dots;
            string[] spaces;
            int wordcount;
            int simple = 0;
            dots = sentences.Split('.','?','!');
            foreach (string str in dots)
            {
                spaces = str.Split(' ');
                wordcount = spaces.Length;

                if (wordcount > simple)
                {
                    simple = wordcount;
                }

             }
            Console.WriteLine("Maximum Number of word in  a Sentense :"+simple);
            Console.Read();
        }
    }
}
