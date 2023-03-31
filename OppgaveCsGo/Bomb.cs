using System;

namespace OppgaveCsGo
{
    internal class Bomb
    {
        public bool Planting;
        public bool Planted => ExplosionCountdown < 16;
        public int ExplosionCountdown { get; private set; }
        public bool Defusing;
        public int DefuseCountdown { get; private set; }

        public Bomb()
        {
            Planting = true;
            Defusing = false;
            ExplosionCountdown = 20;
            DefuseCountdown = 5;
        }
        public void Countdown()
        {
            ExplosionCountdown--;

            if (Defusing)
            {
                DefuseCountdown--;
            }
        }
        public void DefuseBomb()
        {
            Defusing = true; 
        }
    }
}