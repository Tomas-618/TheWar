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
                new Mossberg500(20, 8),
                new AK47(6, 30)
            };
        }
    }
}
