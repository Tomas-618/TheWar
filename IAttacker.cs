using System.Collections.Generic;

namespace CSLight
{
    public interface IAttacker
    {
        void Attack(IReadOnlyList<IDamagable> targets, in int targetIndex);
    }
}
