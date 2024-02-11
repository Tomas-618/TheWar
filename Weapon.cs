using System;

namespace CSLight
{
    public abstract class Weapon : IAttacker
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

        public void Attack(IDamagable target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (_bulletsCount <= 0)
            {
                Reload();

                return;
            }

            _bulletsCount--;
            target.TakeDamage(_damage);
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
