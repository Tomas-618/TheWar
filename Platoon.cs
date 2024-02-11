namespace CSLight
{
    public class Platoon
    {
        private Country _firstCountry;
        private Country _secondCountry;

        public Platoon() =>
            Fill();

        public void Start() { }

        private void Fill()
        {
            _firstCountry = new Country();
            _secondCountry = new Country();
        }
    }
}
