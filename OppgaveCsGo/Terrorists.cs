using System;
namespace OppgaveCsGo
{
    internal class Terrorists
    {
        private Random _random;
        private List<Terrorist> _terrorists;
        public bool AreAllDead => _terrorists.Where(t => t.IsDead).Count() == 5;

        public Terrorists()
        {
            _terrorists = new List<Terrorist>();

            for (int i = 0; i < 5; i++)
            {
                _terrorists.Add(new Terrorist(i+1));
                _random = new Random();
            }
        }
        public Terrorist GetTeamMember()
        {
            var aliveTeamMembers = _terrorists.Where(t => t.IsDead == false).ToList();
            var randomIndex = _random.Next(aliveTeamMembers.Count);

            return aliveTeamMembers[randomIndex];
        }
    }
}

