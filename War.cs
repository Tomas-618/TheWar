using System;

namespace CSLight
{
    public class War
    {
        private Platoon _firstCountry;
        private Platoon _secondCountry;
        private UI _firstCountryUI;
        private UI _secondCountryUI;
        private int _duration;

        public War() =>
            Fill();

        public bool IsRunning => _firstCountry.IsAllive && _secondCountry.IsAllive;

        public void Process()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Platoon firstCountry = _firstCountry;
                Platoon secondCountry = _secondCountry;
                UI firstCountryUI = _firstCountryUI;
                UI secondCountryUI = _secondCountryUI;

                int firstPlatoonChoosePercent = 50;

                if (UserUtils.IsSuccess(firstPlatoonChoosePercent))
                {
                    firstCountry = _secondCountry;
                    secondCountry = _firstCountry;
                    firstCountryUI = _secondCountryUI;
                    secondCountryUI = _firstCountryUI;
                }

                Console.WriteLine("The War is about to begin...\n");
                ShowInfo(firstCountryUI, secondCountryUI);

                while (IsRunning)
                {
                    UserUtils.WaitForClick();
                    Console.Clear();

                    _duration++;
                    Console.Write($"{_duration}) ");

                    firstCountry.Offense(secondCountry.Warriors);
                    secondCountry.RemoveDiedWairriors();

                    secondCountry.Offense(firstCountry.Warriors);
                    firstCountry.RemoveDiedWairriors();

                    ShowInfo(firstCountryUI, secondCountryUI);
                }

                Console.WriteLine("\n");
                ShowResult(firstCountry, secondCountry, _duration);

                Console.WriteLine("\nDo you want to start the War again?");
                isContinue = UserUtils.TryAnswer();
                Console.Clear();

                if (isContinue)
                    Fill();
            }
        }

        private void ShowInfo(UI firstCountryUI, UI secondCountryUI)
        {
            string board = new string('-', 100);

            Console.WriteLine("First platoon: ");
            firstCountryUI.ShowInfo();

            Console.WriteLine($"\n{board}\n");

            Console.WriteLine("Second platoon: ");
            secondCountryUI.ShowInfo();
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
            _firstCountryUI = new UI(_firstCountry);
            _secondCountryUI = new UI(_secondCountry);
            _duration = 0;
        }
    }
}
