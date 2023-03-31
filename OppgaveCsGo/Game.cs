using System;
using OppgaveCsGo;

namespace OppgaveCsGo
{
    internal class Game
    {
        private static Random _random;
        private static Terrorists _terrorists;
        private static CounterTerrorists _counterTerrorists;
        private static Bomb _bomb;
        private static bool _isTerroristsTurn;
        private static bool _searchMode;

        public static void Run()
        {
            _random = new Random();
            _terrorists = new Terrorists();
            _counterTerrorists = new CounterTerrorists();
            _isTerroristsTurn = true;
            _searchMode = true;

            Console.WriteLine("\n**** Welcome to CS GO ****\n");

            while (true)
            {
                if (!_terrorists.AreAllDead && !_counterTerrorists.AreAllDead)
                {
                    Turn();

                    if (_bomb != null && _bomb.Planting)
                    {
                        CountdownMode();
                        break;
                    }
                }
                else break;
            }
            ShowWinner();
        }
        private static void Turn()
        {
            var t = _terrorists.GetTeamMember();
            var ct = _counterTerrorists.GetTeamMember();

            if (_isTerroristsTurn)
            {
                if (_searchMode)
                {
                    if (t.FindBombSite())
                    {
                        _bomb = t.PlantBomb();
                        Console.WriteLine($"Terrorist {t.Player} found the bomb site and planted the bomb!");
                    }
                }
                else if (t.KillCounterTerrorist(ct))
                {
                    Console.WriteLine($"Terrorist {t.Player} killed Counter Terrorist {ct.Player}");
                }
                _searchMode = !_searchMode;
            }
            else if (ct.KillTerrorist(t))
            {
                Console.WriteLine($"Counter Terrorist {ct.Player} killed Terrorist {t.Player}");
            }
            _isTerroristsTurn = !_isTerroristsTurn;
        }
        private static void CountdownMode()
        {
            var counter = 20;
            while (counter > 0)
            {
                ShowCountown();

                if (_counterTerrorists.AreAllDead || _bomb.DefuseCountdown == 0) break;

                else if (_bomb.ExplosionCountdown > 15)
                {
                    Turn();
                }
                else
                {
                    CountdownTurn();
                }
                _bomb.Countdown();
                counter--;
            }
        }
        private static void CountdownTurn()
        {
            var ct = _counterTerrorists.GetTeamMember();

            if (!_terrorists.AreAllDead && _isTerroristsTurn)
            {
                var t = _terrorists.GetTeamMember();
                if (t.KillCounterTerrorist(ct))
                {
                    Console.WriteLine($"Terrorist {t.Player} killed Counter Terrorist {ct.Player}");
                }
            }
            else
            {
                if (!_terrorists.AreAllDead)
                {
                    var t = _terrorists.GetTeamMember();
                    if (ct.KillTerrorist(t, _bomb.Planted))
                    {
                        Console.WriteLine($"Counter Terrorist {ct.Player} killed Terrorist {t.Player}");
                    }
                }
                else
                {
                    _bomb.DefuseBomb();
                }

            }
            _isTerroristsTurn = !_isTerroristsTurn;
        }
        private static void ShowCountown()
        {
            if (_bomb.ExplosionCountdown == 15)
            {
                Console.Write("The bomb has been planted,");
            }
            Console.WriteLine($"{_bomb.ExplosionCountdown} turns until the bomb goes off");
            if (_bomb.Defusing)
            {
                Console.WriteLine($"Defusing bomb {_bomb.DefuseCountdown} turns to go");
            }
        }
        private static void ShowWinner()
        {
            Console.WriteLine();
            if (_bomb != null && _bomb.DefuseCountdown == 0)
            {
                Console.WriteLine("The bomb has been defused, the Counter Terrorists have won the game");
            }
            else if (_bomb != null && _bomb.ExplosionCountdown == 0)
            {
                Console.WriteLine("The bomb exploded, the Terrorists won the game");
            }
            else if (_counterTerrorists.AreAllDead)
            {
                Console.WriteLine($"The Counter Terrorists are all dead, the Terrorists have won the game");
            }
            else
            {
                Console.WriteLine($"The Terrorists are all dead, the Counter Terrorists have won the game");
            }
        }
    }
}

