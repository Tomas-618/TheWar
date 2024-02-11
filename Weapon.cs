namespace CSLight
{
    public abstract class Weapon : IAttackable
    {
        private int _damage;
        private int _bulletsCount;

        public abstract void Attack(IDamagable target);
    }
}
