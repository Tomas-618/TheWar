using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    public class MilitaryBunker
    {
        private readonly IReadOnlyDictionary<Type, Func<IAttacker>> _weaponsMap;

        public MilitaryBunker() =>
            _weaponsMap = InitialazeWeaponMap();

        public IReadOnlyList<Type> AvalaibleWeapons => _weaponsMap.Keys
            .ToArray();

        public IAttacker GetWeapon<T>() where T : IAttacker
        {
            Type type = typeof(T);

            if (_weaponsMap.ContainsKey(type) == false)
                throw new InvalidOperationException("Can't find weapon");

            return _weaponsMap[type].Invoke();
        }

        public IAttacker GetRandomWeapon()
        {
            IReadOnlyList<Type> avalaibleWeapons = AvalaibleWeapons;

            int index = UserUtils.GetRandomNumber(0, avalaibleWeapons.Count - 1);

            return _weaponsMap[avalaibleWeapons[index]].Invoke();
        }

        private Dictionary<Type, Func<IAttacker>> InitialazeWeaponMap()
        {
            return new Dictionary<Type, Func<IAttacker>>
            {
                [typeof(M1911)] = () => new M1911(new CartridgeClip(30, 7)),
                [typeof(Mossberg500)] = () => new Mossberg500(new CartridgeClip(20, 8)),
                [typeof(AK47)] = () => new AK47(new CartridgeClip(6, 30))
            };
        }
    }
}
