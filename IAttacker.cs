using System.Collections.Generic;

namespace CSLight
{
    public interface IAttacker
    {
        void Attack(params IDamagable[] target);
    }
}
