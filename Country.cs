using System.Collections.Generic;

namespace CSLight
{
    public class Country
    {
        public const int MinWarriorsCount = 100;
        public const int MaxWarriorsCount = 500;

        private List<Warrior> _warriors;

        public Country() =>
            Fill();

        private void Fill()
        {
            int warriorsCount = UserUtils.GetRandomNumber(MinWarriorsCount, MaxWarriorsCount);

            _warriors = new List<Warrior>();

            for (int i = 0; i < warriorsCount; i++)
            {
                _warriors.Add(new Warrior());
            }
        }
    }
}
