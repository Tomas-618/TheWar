using System;

namespace CSLight
{
    public class UI
    {
        private Platoon _platoon;

        public UI(Platoon platoon) =>
            Fill(platoon);

        public void ShowInfo()
        {
            for (int i = 0; i < _platoon.Warriors.Count; i++)
            {
                int currentWarriorIndex = i.GetIncreasedByOne();

                Console.WriteLine($"{currentWarriorIndex}) {_platoon.Warriors[i]}");
            }
        }

        private void Fill(Platoon platoon)
        {
            if (platoon == null)
                throw new ArgumentNullException(nameof(platoon));

            _platoon = platoon;
        }
    }
}
