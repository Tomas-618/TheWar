using System;

namespace CSLight
{
    public class Warrior : IDamagable, IAttacker
    {
        public const int MaxHealth = 100;

        private Weapon _weapon;
        private int _health;

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
        public bool IsAlive => Health > 0;

        public Warrior(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            Fill(weapon);
        }

        public void TakeDamage(in int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Health -= damage;
        }

        public void Attack(IDamagable target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            _weapon.Attack(target);
        }

        private void Fill(Weapon weapon)
        {
            _weapon = weapon;
            _health = MaxHealth;
        }
    }
}
