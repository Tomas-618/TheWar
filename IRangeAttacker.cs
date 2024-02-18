using System.Collections.Generic;

namespace CSLight
{
    public interface IRangeAttacker
    {
        void AttackInRange(IReadOnlyList<IDamagable> targets, params int[] targetToAttackIndex);
    }
}
