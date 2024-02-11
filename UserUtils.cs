using System;

namespace CSLight
{
    public struct UserUtils
    {
        private static readonly Random _random;

        static UserUtils() =>
            _random = new Random();

        public static int GetRandomNumber() =>
            _random.Next();

        public static int GetRandomNumber(in int maxValue) =>
            _random.Next(maxValue.GetIncreasedByOne());

        public static int GetRandomNumber(in int minValue, in int maxValue) =>
            _random.Next(minValue, maxValue.GetIncreasedByOne());
    }
}
