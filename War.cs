namespace CSLight
{
    public class War
    {
        private Platoon _firstCountry;
        private Platoon _secondCountry;

        public War() =>
            Fill();

        public bool IsRunning => _firstCountry.IsAllive && _secondCountry.IsAllive;

        public void Start()
        {
            while (IsRunning)
            {
                _firstCountry.MakeOffensive(_secondCountry.Warriors);
                _secondCountry.MakeOffensive(_firstCountry.Warriors);
            }
        }

        private void Fill()
        {
            _firstCountry = new Platoon();
            _secondCountry = new Platoon();
        }
    }
}
