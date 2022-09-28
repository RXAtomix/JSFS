using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class OnlineGameManager
    {
        private readonly OnlinePlayer _player;
        private readonly Socket _gameSocket;
        private readonly Displayer _disp;
        private bool _playing;

        public OnlineGameManager(OnlinePlayer player, string port , string ip = null)
        {
            _player = player;
            _playing = ip == null;
            _gameSocket = Connect(ip, port, _playing);
            if (_player.IsDisplay())
                _disp = new Displayer(player);
            foreach (Ship.ShipType type in Enum.GetValues(typeof(Ship.ShipType)))
            {
                _player.GenerateShip(type);
            }
        }

        public Socket Connect(string ip, string port, bool first)
        {
            var gameSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!Int32.TryParse(port, out int portint))
                return gameSocket;
            if (first)
            {
                var serv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serv.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), portint));
                serv.Listen(1);
                gameSocket = serv.Accept();
            }
            else
                gameSocket.Connect(new IPEndPoint(IPAddress.Parse(ip), portint));
            return gameSocket;
        }

        private byte[] Serialize(int result, Coordinate target)
        {
            string data = "" + (char)result + (char)target.GetX() + (char)target.GetY();
            return Encoding.UTF8.GetBytes(data);
        }


        private void Deserialize(byte[] data, out int result, out Coordinate shot)
        {
            string results = Encoding.UTF8.GetString(data);
            result = results[0];
            shot = new Coordinate(results[1], results[2]);
        }

        public void Play()
        {
            int lasthit = 0;
            byte[] buffer = new byte[8];
            Coordinate lastshot = null;
            if (_disp != null)
                _disp.Create();
            while (_gameSocket.Connected && !(_player.HasWon() || _player.HasLost()))
            {
                if (_disp != null)
                    _disp.UpdateGui();
                if (_playing)
                {
                    Console.WriteLine("Where to shoot Captain ?");
                    lastshot = _player.Shoot();
                    _gameSocket.Send(Serialize(lasthit, lastshot));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Coordinate ennemyShot;
                    _gameSocket.Receive(buffer);
                    Deserialize(buffer, out lasthit, out ennemyShot);
                    if (lastshot != null)
                    {
                        switch (lasthit)
                        {
                            case 0:
                                Console.WriteLine("We missed Cap'tain !");
                                break;
                            case 1:
                                Console.WriteLine("We hit Cap'tain !");
                                break;
                            case 2:
                                Console.WriteLine("We sunk a ship Cap'tain !");
                                break;
                        }
                        _player.setCell(lastshot, lasthit);
                    }
                    lasthit = _player.ReceiveShotVersus(ennemyShot);
                    switch (lasthit)
                    {
                        case 0:
                            Console.WriteLine("They missed Cap'tain !");
                            break;
                        case 1:
                            Console.WriteLine("They hit Cap'tain !");
                            break;
                        case 2:
                            Console.WriteLine("They sunk a ship Cap'tain !");
                            break;
                    }
                    Console.ResetColor();
                    _player.GetMap().PrettyPrint(_player.GetMap().ToString());
                }
                _playing = !_playing;
            }
            _gameSocket.Disconnect(true);
        }
    }
}
