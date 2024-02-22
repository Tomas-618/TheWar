using System;
using System.Collections.Generic;

namespace CSLight
{
    public class Warrior : IAttacker, IDamagable, IReadOnlyHealth
    {
        public const int MaxHealth = 100;

        private IAttacker _weapon;
        private int _health;
        private int _armor;

        public int Health
        {
            get => _health;
            private set
            {
                if (value >= MaxHealth)
                    _health = MaxHealth;
                else if (value <= 0)
                    _health = 0;
                else
                    _health = value;
            }
        }

        public bool IsDied => Health <= 0;

        public Warrior(IAttacker weapon, in int armor) =>
            Fill(weapon, armor);

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException($"damage: {damage}");

            int minDamage = 1;

            damage -= _armor;
            UserUtils.LimitNumberInRange(ref damage, minDamage);

            Health -= damage;
        }

        public void Attack(IReadOnlyList<IDamagable> targets, in int targetIndex)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            _weapon.Attack(targets, targetIndex);
        }

        public override string ToString() =>
            $"Health = {Health} || Armor = {_armor} || Weapon: {_weapon}";

        private void Fill(IAttacker weapon, in int armor)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            if (armor < 0)
                throw new ArgumentOutOfRangeException(nameof(armor));

            _weapon = weapon;
            _health = MaxHealth;
            _armor = armor;
        }
    }
}
