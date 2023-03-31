namespace OppgaveCsGo
{
    internal class CounterTerrorist
    {
        public readonly int Player;
        public bool IsDead { get; set; }

        public CounterTerrorist(int player)
        {
            Player = player;
            IsDead = false;
        }
        public bool KillTerrorist(Terrorist terrorist, bool bombIsPlanted = false)
        {
            var randomness = bombIsPlanted ? 3 : 5;
            if (IsSuccessful(randomness))
            {
                terrorist.IsDead = true;
                return true;
            }
            else return false;
        }
        public void DefuseBomb(Bomb bomb)
        {
            bomb.DefuseBomb();
        }
        public bool IsSuccessful(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(0, maxValue) == 2;
        }
    }
}