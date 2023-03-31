using System;
namespace OppgaveCsGo
{
    internal class CounterTerrorists
    {
        private Random _random;
        private List<CounterTerrorist> _counterTerrorists;
        public bool AreAllDead => _counterTerrorists.Where(t => t.IsDead).Count() == 5;

        public CounterTerrorists()
        {
            _random = new Random();
            _counterTerrorists = new List<CounterTerrorist>();

            for (int i = 0; i < 5; i++)
            {
                _counterTerrorists.Add(new CounterTerrorist(i+1));
            }
        }
        public CounterTerrorist GetTeamMember()
        {
            var aliveTeamMembers = _counterTerrorists.Where(t => t.IsDead == false).ToList();
            var randomIndex = _random.Next(aliveTeamMembers.Count);

            return aliveTeamMembers[randomIndex];
        }   
    }
}

