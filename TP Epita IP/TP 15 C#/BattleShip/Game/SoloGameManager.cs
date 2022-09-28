using System;
using System.Collections.Generic;

namespace BattleShip
{

    public class SoloGameManager
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly List<Displayer> _displayers;

        public SoloGameManager(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            foreach (Ship.ShipType type in Enum.GetValues(typeof(Ship.ShipType)))
            {
                _player1.GenerateShip(type);
                _player2.GenerateShip(type);
            }
            _displayers = new List<Displayer>();
            if (player1.IsDisplay())
                _displayers.Add(new Displayer(player1));
            if (player2.IsDisplay())
                _displayers.Add(new Displayer(player2));
        }

        public void Play()
        {
            Player current = _player1;
            Player adv = _player2;
            foreach (Displayer disp in _displayers)
                disp.Create();

            while (!current.HasLost())
            {
                Coordinate c = current.Shoot();
                current.SetCell(c, adv.ReceiveShoot(c));
                Player tmp = current;
                current = adv;
                adv = tmp;
                foreach (Displayer disp in _displayers)
                    disp.UpdateGui();
            }

            current.GetMap().PrettyPrint(current.GetMap().ToString());
            adv.GetMap().PrettyPrint(adv.GetMap().ToString());
        }
    }
}
