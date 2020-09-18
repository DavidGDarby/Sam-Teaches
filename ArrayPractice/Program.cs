using System;
using System.Collections.Generic;
using System.Threading;

namespace ArrayPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our testing facilities.\nEnter 'Y' and a testing unit will assist you.\nEnter any other character to exit the facility.");
            string input = Console.ReadLine().ToLower();
            while (InputYes(input))
            {
                Laboratory();
            }

        }
        public static void Laboratory()
        {
            Random rnd = new Random();
            string input = "Y";
            int arraySize = -1;
            int arrayLimit = -1;

            Console.Clear();
            Console.Write("Hello");
            SlowString("...", 320);
            Console.Write("Friend\nI am testing unit ZSN4G");
            Console.WriteLine("\nWould you like to help me with some experiments? 'Y' or 'N'");
            Console.ReadLine();
            Console.WriteLine("Of course you would! Let us get started.\nFirst, we will need an array of numbers.");

            do
            {
                Console.WriteLine("How many numbers should our array contain?");
                if (!int.TryParse(Console.ReadLine(), out arraySize) || arraySize < 1)
                {
                    Console.WriteLine("Please input a number greater than 0.");
                }
            }
            while (arraySize < 1);

            do
            {
                Console.WriteLine("Let us set a limit on how large these numbers can be.\nWhat is the largest they can be?");
                if (!int.TryParse(Console.ReadLine(), out arrayLimit) || arrayLimit < 1)
                {
                    Console.WriteLine("Please input a number greater than 0.");
                }
            }
            while (arrayLimit < 1);

            int[] experiment = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                experiment[i] = rnd.Next(1, arrayLimit + 1);
            }

            Console.WriteLine("Excellent!\nNow, let's use this for our experiments.");

            int sum = ArraySum(experiment);
            Console.WriteLine($"The sum of our array is {sum}.");

            double average = ArrayAverage(sum, arraySize);
            Console.WriteLine($"The average of our array is {average}.");

            NiceCheck(experiment);

            Console.WriteLine("Ready to get advanced? 'Y' or 'N'");
            Console.ReadLine();

            Console.WriteLine("Of course you are!\nHere is our array sorted:");
            ArraySort(experiment);

            //Console.WriteLine("Are the experiments becoming too hard to follow? 'Y' 'N'");
            //Console.ReadLine();
            //SlowString("I can slow things down...", 135);

            List<int> arrayList = new List<int>();
            Console.WriteLine("\n\nNext, I will need to make our array in to a list.\nCalculating");
            SlowString("............", 265);

            foreach (int num in experiment)
            {
                arrayList.Add(num);
            }
            Console.WriteLine("Done!");
            Console.WriteLine("Here is the lowest number in our list.");
            ListMin(arrayList);
            Console.WriteLine("\nNext will need a list of words.");

            int words = 0;
            int count = 5;
            List<string> stringList = new List<string>();
            while (words < 5)
            {
                if (count == 1)
                {
                    Console.WriteLine($"Please enter {count} more word.");
                }
                else
                {
                    Console.WriteLine($"Please enter {count} more words.");
                }
                stringList.Add(Console.ReadLine());
                words++;
                count--;
            }
            //Console.WriteLine("\n");
            SlowString("Hmmm...", 150);
            Console.WriteLine("Not the ones I would have used but they will work.\n");

            StringCount(stringList);

            StringMax(stringList);

            Console.WriteLine("I hope this isn't too advanced for you...\nPlease type in any sentence.");
            StringIndex(Console.ReadLine());

            NumberIndex(experiment, rnd.Next(0, arraySize));

            do
            {
                Console.WriteLine("\nIf you would like to view our array again enter 'A'.\nTo return to the facilities entrance enter 'T'");
                Console.WriteLine("To exit, enter 'X'.");
                input = Console.ReadLine().ToLower();
                if (input == "a")
                {
                    for (int i = 0; i < experiment.Length; i++)
                    {
                        if (i < experiment.Length - 1)
                        {
                            Console.Write($"{experiment[i]}, ");
                        }
                        else if (i == experiment.Length - 1)
                        {
                            Console.Write($"{experiment[i]}");
                        }
                    }
                    continue;
                }
                else if (input == "t")
                {
                    break;
                }
            }
            while (input != "t");
            
        }
        public static bool InputYes(string input)
        {
            if (input == "y")
            {
                return true;
            }
            return false;
        }
        public static void SlowString(string slowly, int ms)
        {

            foreach (char c in slowly)
            {
                Console.Write(c);
                Thread.Sleep(ms);
            }
        }
        public static int ArraySum(int[] experiment)
        {
            int sum = 0;
            for (int i = 0; i < experiment.Length; i++)
            {
                sum = sum + experiment[i];
            }
            return sum;
        }
        public static double ArrayAverage(int sum, int arraySize)
        {
            return (double)sum / (double)arraySize;
        }
        public static void ArraySort(int[] experiment)
        {
            int temp;
            for (int i = 0; i < experiment.Length - 1; i++)
            {
                for (int j = i + 1; j < experiment.Length; j++)
                {
                    if (experiment[i] < experiment[j])
                    {
                        temp = experiment[i];
                        experiment[i] = experiment[j];
                        experiment[j] = temp;
                    }
                }
            }
            for (int i = 0; i < experiment.Length; i++)
            {
                if (i < experiment.Length - 1)
                {
                    Console.Write($"{experiment[i]}, ");
                }
                else if (i == experiment.Length - 1)
                {
                    Console.Write($"{experiment[i]}");
                }
            }
        }
        public static void ListMin(List<int> anyList)
        {
            int temp;
            for (int i = 0; i < anyList.Count - 1; i++)
            {
                for (int j = i + 1; j < anyList.Count; j++)
                {
                    if (anyList[i] > anyList[j])
                    {
                        temp = anyList[i];
                        anyList[i] = anyList[j];
                        anyList[j] = temp;
                    }
                }
            }
            Console.WriteLine(anyList[0]);
        }
        public static void NiceCheck(int[] experiment)
        {
            foreach (int value in experiment)
                if (value == 69)
                {
                    Console.WriteLine("69 exists in our array, nice.");
                    break;
                }
        }
        public static void StringCount(List<string> anyList)
        {
            int count = 0;
            char charToCount = 'i';
            foreach (string str in anyList)
            {
                foreach (char c in str)
                {
                    if (c == charToCount)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"The letter 'I' appears {count} times in our list.");
        }
        public static void StringMax(List<string> anyList)
        {
            string bigString = string.Empty;
            foreach (string str in anyList)
            {
                if (str.Length > bigString.Length)
                {
                    bigString = str;
                }
            }
            Console.WriteLine($"'{bigString}' is the largest word you entered");
        }
        public static void StringIndex(string anyString)
        {
            int index = 0;
            foreach (char ch in anyString)
            {
                index++;
                if (index == 5)
                {
                    Console.WriteLine($"{ch} is index position 5 of '{anyString}'");
                }
            }
        }
        public static void NumberIndex(int [] anyArray, int rnd)
        {            
            for (int i = 0; i < anyArray.Length; i++)
            {
                if (i == rnd)
                {
                    Console.Write($"{anyArray[i]} is in {rnd} index position of our array.");
                }              
            }
        }


    }
}
