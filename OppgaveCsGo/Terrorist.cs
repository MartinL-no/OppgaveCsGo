using OppgaveCsGo;

namespace OppgaveCsGo
{
    internal class Terrorist
    {
        public readonly int Player;
        public bool IsDead { get; set; }

        public Terrorist(int player)
        {
            Player = player;
            IsDead = false;
        }
        public bool FindBombSite()
        {
            if (IsSuccessful(10)) return true;
           
            else return false;
            
        }
        public bool KillCounterTerrorist(CounterTerrorist counterTerrorist)
        {
            if (IsSuccessful(7))
            {
                counterTerrorist.IsDead = true;
                return true;
            }
            else return false;
        }
        public Bomb PlantBomb()
        {
            return new Bomb();
        }
        public bool IsSuccessful(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(0, maxValue) == 2;
        }
    }
}