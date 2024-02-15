using System;

namespace CSLight
{
    public class War
    {
        private Platoon _firstCountry;
        private Platoon _secondCountry;
        private int _duration;

        public War() =>
            Fill();

        public bool IsRunning => _firstCountry.IsAllive && _secondCountry.IsAllive;

        public void Start()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Platoon firstCountry = _firstCountry;
                Platoon secondCountry = _secondCountry;

                int firstPlatoonChoosePercent = 50;

                if (UserUtils.IsChanceTrue(firstPlatoonChoosePercent))
                {
                    firstCountry = _secondCountry;
                    secondCountry = _firstCountry;
                }

                Console.WriteLine("The War is about to begin...");

                while (IsRunning)
                {
                    //UserUtils.WaitForClick();
                    Console.WriteLine("\n");

                    _duration++;
                    Console.Write($"{_duration}) ");

                    firstCountry.Attack(secondCountry.Warriors);
                    secondCountry.RemoveDiedWairriors();

                    secondCountry.Attack(firstCountry.Warriors);
                    firstCountry.RemoveDiedWairriors();

                }

                Console.WriteLine("\n");
                ShowResult(firstCountry, secondCountry, _duration);

                Console.WriteLine("\nDo you want to start the War again?");
                isContinue = UserUtils.IsEnteredDesiredAnswer();
                Console.Clear();

                if (isContinue)
                    Fill();
            }
        }

        private void ShowResult(Platoon firstCountry, Platoon secondCountry, in int duration)
        {
            if (firstCountry.IsAllive == false)
                Console.WriteLine("Second country won!");
            else if (secondCountry.IsAllive == false)
                Console.WriteLine("First country won!");
            else
                Console.WriteLine("Draw");

            Console.WriteLine(firstCountry.Warriors.Count);
            Console.WriteLine(secondCountry.Warriors.Count);
            Console.WriteLine($"Duration: {duration}");
        }

        private void Fill()
        {
            _firstCountry = new Platoon();
            _secondCountry = new Platoon();
            _duration = 0;
        }
    }
}
