using System;

namespace CSLight
{
    public struct UserUtils
    {
        public const int MinPercent = 1;
        public const int MaxPercent = 100;

        private static readonly Random _random;

        static UserUtils() =>
            _random = new Random();

        public static bool IsEnteredDesiredAnswer(string positive = "yes", string negative = "no")
        {
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != positive.ToLower() && userInput.ToLower() != negative.ToLower())
            {
                Console.WriteLine("\nError! Try again!");
                userInput = Console.ReadLine();
            }

            return userInput.ToLower() == positive.ToLower();
        }

        public static void LimitNumberInRange(ref int value, in int minValue)
        {
            if (value <= minValue)
                value = minValue;
        }

        public static void WaitForClick(string text = "\nPress any key to continue... ")
        {
            Console.Write(text);
            Console.ReadKey(true);
        }

        public static bool IsChanceTrue(in int desiredPercent)
        {
            if (desiredPercent < 0 || desiredPercent > MaxPercent)
                throw new ArgumentOutOfRangeException(nameof(desiredPercent));

            int randomPercent = _random.Next(MinPercent, MaxPercent.GetIncreasedByOne());

            return randomPercent <= desiredPercent;
        }

        public static int GetRandomNumber(in int maxValue) =>
            _random.Next(maxValue.GetIncreasedByOne());

        public static int GetRandomNumber(in int minValue, in int maxValue) =>
            _random.Next(minValue, maxValue.GetIncreasedByOne());
    }
}
