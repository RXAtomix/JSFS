using System.Drawing;
using System.Windows.Forms;

namespace BattleShip
{
    public class Displayer : Form
    {
        private readonly IDisplayable _player;

        private Grid _grid;

        public Displayer(IDisplayable player)
        {
            _player = player;
        }

        public void Create()
        {
            Text = _player.GetName();
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            _grid = new Grid { Dock = DockStyle.Fill };
            Size = new Size(588, 320);
            MaximumSize = Size;
            Controls.Add(_grid);
            Show();
        }

        public void UpdateGui()
        {
            _grid?.UpdateGui(_player.GetMap().GetShips(), _player.GetMap().GetMatrix());
        }
    }
}
