using System;
using System.Collections.Generic;

namespace CSLight
{
    public class CartridgeClip : IRangeAttacker
    {
        private readonly int _maxBulletsCount;

        private int _damage;
        private int _bulletsCount;

        public CartridgeClip(in int damage, in int maxBulletsCount)
        {
            if (damage <= 0 || maxBulletsCount <= 0)
                throw new ArgumentOutOfRangeException();

            _maxBulletsCount = maxBulletsCount;
            Fill(damage);
        }

        public int BulletsInClipCount => _maxBulletsCount;
        public bool IsHaveBullets => _bulletsCount > 0;

        public void AttackInRange(IReadOnlyList<IDamagable> targets, params int[] indexesAttackRange)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (IsHaveBullets == false)
            {
                Reload();

                return;
            }

            _bulletsCount--;

            foreach (int targetIndex in indexesAttackRange)
            {
                if (targets.ContainsKey(targetIndex))
                    targets[targetIndex].TakeDamage(_damage);
            }
        }

        private void Reload() =>
            _bulletsCount = _maxBulletsCount;

        private void Fill(in int damage)
        {
            _damage = damage;
            Reload();
        }

        public override string ToString() =>
            $"Damage = {_damage} || Bullets count: {_bulletsCount}";
    }
}
