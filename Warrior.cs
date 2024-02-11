namespace CSLight
{
    public class Warrior : IDamagable, IAttackable
    {
        private Weapon _weapon;

        public Warrior() =>
            Fill();

        public void TakeDamage() { }

        public void Attack(IDamagable target) =>
            _weapon.Attack(target);

        private void Fill() { }
    }
}
