namespace CSLight
{
    public static class Int32Extension
    {
        public static int GetIncreasedByOne(this int value) =>
            ++value;

        public static int GetReducedByOne(this int value) =>
            --value;
    }
}
