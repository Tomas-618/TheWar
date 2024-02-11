using System.Collections.Generic;

namespace CSLight
{
    public class MilitaryBunker
    {
        private readonly List<Weapon> _weapons;

        public MilitaryBunker() =>
            _weapons = CreateWeapons();

        public IReadOnlyList<Weapon> Weapons => _weapons;

        private List<Weapon> CreateWeapons()
        {
            return new List<Weapon>
            {
                new M1911(30, 7),
                new AK47(10, 30),
                new Mossberg500(12, 8)
            };
        }
    }
}
