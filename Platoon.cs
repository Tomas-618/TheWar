using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    public class Platoon
    {
        public const int MinWarriorsCount = 100;
        public const int MaxWarriorsCount = 500;

        private readonly MilitaryBunker _bunker;

        private List<Warrior> _warriors;

        public Platoon()
        {
            _bunker = new MilitaryBunker();

            Fill();
        }

        public IReadOnlyList<Warrior> Warriors => _warriors;

        public bool IsAllive => Warriors.Count > 0;

        public void MakeOffensive(IReadOnlyList<Warrior> enemies)
        {
            if (enemies == null)
                throw new ArgumentNullException(nameof(enemies));

            _warriors = _warriors.Where(warrior => warrior.IsAlive).ToList();

            if (_warriors.Count <= 0)
                return;

            for (int i = 0; i < enemies.Count; i++)
            {
                int currentWarriorIndex = i % Warriors.Count;

                Warriors[currentWarriorIndex].Attack(enemies[i]);
            }
        }

        private void Fill()
        {
            int warriorsCount = UserUtils.GetRandomNumber(MinWarriorsCount, MaxWarriorsCount);

            _warriors = new List<Warrior>();

            for (int i = 0; i < warriorsCount; i++)
            {
                int weaponIndex = UserUtils.GetRandomNumber(_bunker.Weapons.Count.GetReducedByOne());

                _warriors.Add(new Warrior(_bunker.Weapons[weaponIndex]));
            }
        }
    }
}
