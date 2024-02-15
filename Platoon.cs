using System;
using System.Collections.Generic;

namespace CSLight
{
    public class Platoon
    {
        private readonly MilitaryBunker _bunker;

        private List<Warrior> _warriors;

        public Platoon()
        {
            _bunker = new MilitaryBunker();

            Fill();
        }

        public IReadOnlyList<IDamagable> Warriors => _warriors;

        public bool IsAllive => Warriors.Count > 0;
        
        public void Attack(IReadOnlyList<IDamagable> enemies)
        {
            if (enemies == null)
                throw new ArgumentNullException(nameof(enemies));

            if (_warriors.Count <= 0)
                return;

            for (int i = 0; i < enemies.Count; i++)
            {
                int currentWarriorIndex = i % _warriors.Count;

                _warriors[currentWarriorIndex].Attack(enemies);
            }
        }

        public void RemoveDiedWairriors() =>
            _warriors.RemoveAll(warrior => warrior.IsDied);

        private void Fill()
        {
            int minWarriorsCount = 100;
            int maxWarriorsCount = 500;

            int warriorsCount = UserUtils.GetRandomNumber(minWarriorsCount, maxWarriorsCount);

            _warriors = new List<Warrior>();

            for (int i = 0; i < warriorsCount; i++)
            {
                int maxArmor = 70;

                int weaponIndex = UserUtils.GetRandomNumber(_bunker.Weapons.Count.GetReducedByOne());
                int armor = UserUtils.GetRandomNumber(maxArmor);

                _warriors.Add(new Warrior(_bunker.Weapons[weaponIndex], armor));
            }
        }
    }
}
