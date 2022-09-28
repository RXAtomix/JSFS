using System;
using System.Windows.Forms;

namespace BattleShip
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Menu();
        }

        private static void PlaySolo()
        {
            Player player1 = new Player("HAL 9000", true);
            Player player2 = new Player("GlaDOS", true);
            SoloGameManager gameManager = new SoloGameManager(player1, player2);
            gameManager.Play();
            Application.Run();
        }

        private static void Menu()
        {
            Console.WriteLine("Play online ? [y/N]");
            if (Console.ReadLine() != "y")
                PlaySolo();
            else
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                string ip = null;
                Console.WriteLine("Enter the port to use: ");
                string port = Console.ReadLine();

                Console.WriteLine("Host the game ? [Y/n]");
                if (Console.ReadLine() == "n")
                {
                    Console.WriteLine("Enter your opponent's IP: ");
                    ip = Console.ReadLine();
                }

                new OnlineGameManager(new OnlinePlayer(name, false), port, ip).Play();
            }
        }
    }
}