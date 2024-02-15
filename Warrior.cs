using System;
using System.Collections.Generic;

namespace CSLight
{
    public class Warrior : IDamagable, IReadOnlyHealth
    {
        public const int MaxHealth = 100;

        private Weapon _weapon;
        private int _health;
        private int _armor;

        public int Health
        {
            get => _health;
            set
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

        public Warrior(Weapon weapon, in int armor) =>
            Fill(weapon, armor);

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            int minDamage = 1;

            damage -= _armor;
            UserUtils.LimitNumberInRange(ref damage, minDamage);

            Health -= damage;
        }

        public void Attack(IReadOnlyList<IDamagable> enemies)
        {
            if (enemies == null)
                throw new ArgumentNullException(nameof(enemies));

            _weapon.Attack(enemies);
        }

        private void Fill(Weapon weapon, in int armor)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            if (armor < 0)
                throw new ArgumentOutOfRangeException(nameof(armor));

            _weapon = weapon;
            _health = MaxHealth;
        }
    }
}
