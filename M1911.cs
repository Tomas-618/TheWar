using System;
using System.Collections.Generic;

namespace CSLight
{
    public class M1911 : IAttacker
    {
        private readonly CartridgeClip _clip;

        public M1911(CartridgeClip clip)
        {
            if (clip == null)
                throw new ArgumentNullException(nameof(clip));

            _clip = clip;
        }

        public void Attack(IReadOnlyList<IDamagable> targets, in int targetIndex)
        {
            int desiredPercent = 60;

            if (UserUtils.IsSuccess(desiredPercent))
                _clip.AttackInRange(targets, targetIndex);
        }

        public override string ToString() =>
            $"({nameof(M1911)}: {_clip})";
    }
}
