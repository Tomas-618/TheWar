using System;
using System.Collections.Generic;

namespace CSLight
{
    public class AK47 : IAttacker
    {
        private readonly CartridgeClip _clip;

        public AK47(CartridgeClip clip)
        {
            if (clip == null)
                throw new ArgumentNullException(nameof(clip));

            _clip = clip;
        }

        public void Attack(IReadOnlyList<IDamagable> targets, in int targetIndex)
        {
            if (_clip.IsHaveBullets == false)
            {
                _clip.AttackInRange(targets, targetIndex);

                return;
            }

            for (int i = 0; i < _clip.BulletsInClipCount; i++)
            {
                int currentTargetIndex = (targetIndex + i) % targets.Count;

                _clip.AttackInRange(targets, currentTargetIndex);
            }
        }

        //public override string ToString() =>
        //    $"({nameof(AK47)}: {_clip})";
    }
}
