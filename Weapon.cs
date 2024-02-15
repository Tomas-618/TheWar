using System;
using System.Collections.Generic;

namespace CSLight
{
    public abstract class Weapon
    {
        private readonly int _bulletsInClipCount;

        private int _damage;
        private int _bulletsCount;

        public Weapon(in int damage, in int bulletsInClipCount)
        {
            if (damage <= 0 || bulletsInClipCount <= 0)
                throw new ArgumentOutOfRangeException();

            _bulletsInClipCount = bulletsInClipCount;
            Fill(damage);
        }

        public void Attack(IReadOnlyList<IDamagable> enemies)
        {
            if (enemies == null)
                throw new ArgumentNullException(nameof(enemies));

            if (_bulletsCount <= 0)
            {
                Reload();

                return;
            }

            _bulletsCount--;
            enemies[0].TakeDamage(_damage);
        }

        private void Reload() =>
            _bulletsCount = _bulletsInClipCount;

        private void Fill(in int damage)
        {
            _damage = damage;
            Reload();
        }
    }
}
