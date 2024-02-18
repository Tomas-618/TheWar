using System;
using System.Collections.Generic;

namespace CSLight
{
    public class Mossberg500 : IAttacker
    {
        private readonly CartridgeClip _clip;

        public Mossberg500(CartridgeClip clip)
        {
            if (clip == null)
                throw new ArgumentNullException(nameof(clip));

            _clip = clip;
        }

        public void Attack(IReadOnlyList<IDamagable> targets, in int targetIndex) =>
            _clip.AttackInRange(targets, targetIndex, targetIndex.GetReducedByOne(), targetIndex.GetIncreasedByOne());

        public override string ToString() =>
            $"({nameof(Mossberg500)}: {_clip})";
    }
}
