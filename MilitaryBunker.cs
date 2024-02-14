using System.Collections.Generic;

namespace CSLight
{
    public class MilitaryBunker
    {
        public MilitaryBunker() =>
            Weapons = CreateWeapons();

        public IReadOnlyList<Weapon> Weapons { get; private set; }

        private List<Weapon> CreateWeapons()
        {
            return new List<Weapon>
            {
                new M1911(30, 7),
                new GrenadeLauncher(10, 30),
                new Mossberg500(12, 8)
            };
        }
    }
}
