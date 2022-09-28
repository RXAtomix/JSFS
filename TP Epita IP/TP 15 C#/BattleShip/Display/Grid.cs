using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BattleShip;

namespace BattleShip
{
    public sealed class Grid : Panel
    {
        private readonly Bitmap _boatSprites;
        private readonly Bitmap _backGrid;

        private List<Ship> _ships;
        private Cell[][] _matrix;

        public Grid()
        {
            try
            {
                _boatSprites = new Bitmap(Properties.Resources.boats);
                _backGrid = new Bitmap(Properties.Resources.battleship);
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Error while loading images");
            }

            BackgroundImage = _backGrid;
            BackgroundImageLayout = ImageLayout.Tile;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Paint += GridPaint;
        }


        protected override void Dispose(bool disposing)
        {
            _backGrid.Dispose();
            _boatSprites.Dispose();
            base.Dispose(disposing);
        }

        private void GridPaint(object sender, PaintEventArgs e)
        {
            if (_ships != null)
            {
                foreach (var ship in _ships)
                {
                    DrawShip(e.Graphics, ship);
                }
            }

            if (_matrix != null)
            {
                foreach (var cells in _matrix)
                {
                    foreach (var cell in cells)
                    {
                        DrawCell(e.Graphics, cell);
                    }
                }
            }
        }

        public void UpdateGui(List<Ship> ships, Cell[][] matrix)
        {
            _ships = ships;
            _matrix = matrix;
            Refresh();
        }

        private Bitmap Crop(int x, int y, int h, int w)
        {
            Rectangle rec = new Rectangle(x, y, h, w);
            Bitmap newBitmap = new Bitmap(rec.Width, rec.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(_boatSprites, -rec.X, -rec.Y);
            }
            return newBitmap;
        }

        private void DrawShip(Graphics g, Ship s)
        {
            Bitmap ship;
            Bitmap crop;

            switch (s.GetShipType())
            {
                case Ship.ShipType.AIRCRAFT:
                    crop = Crop(28, 149, 205 - 28, _boatSprites.Height - 149);
                    ship = new Bitmap(crop, crop.Width - 40, crop.Height - 5);
                    break;
                case Ship.ShipType.BATTLESHIP:
                    crop = Crop(28, 104, 177 - 28, 134 - 104);
                    ship = new Bitmap(crop, crop.Width - 40, crop.Height);
                    break;
                case Ship.ShipType.SUBMARINE:
                    crop = Crop(28, 40, 137 - 28, 71 - 40);
                    ship = new Bitmap(crop, crop.Width - 26, crop.Height);
                    break;
                case Ship.ShipType.DESTROYER:
                    crop = Crop(28, 71, 128 - 28, 103 - 71);
                    ship = new Bitmap(crop, crop.Width - 20, crop.Height);
                    break;
                case Ship.ShipType.PATROLBOAT:
                    crop = Crop(28, 9, 98 - 28, 40 - 9);
                    ship = new Bitmap(crop, crop.Width - 10, crop.Height);
                    break;
                default:
                    throw new ArgumentException();
            }
            if (!s.IsHorizontal())
                ship.RotateFlip(RotateFlipType.Rotate90FlipNone);

            int initialX = 20 + s.GetCoordinates()[0].GetX() * 26;
            int initialY = 15 + s.GetCoordinates()[0].GetY() * 26;

            g.DrawImage(ship, initialX, initialY, ship.Width, ship.Height);

            crop.Dispose();
            ship.Dispose();
        }

        private void DrawEllipse(Graphics g, int initialX, int initialY, Cell.State state)
        {
            if (state == Cell.State.HIT)
            {
                g.FillEllipse(Brushes.Crimson, initialX, initialY, 10, 10);
            }
            else if (state == Cell.State.MISSED)
            {
                g.FillEllipse(Brushes.White, initialX, initialY, 10, 10);
            }
        }

        private void DrawCell(Graphics g, Cell c)
        {
            int initialX = 30 + c.GetCoordinate().GetX() * 26;
            int initialY = 25 + c.GetCoordinate().GetY() * 26;
            DrawEllipse(g, initialX, initialY, c.GetHstate());

            initialX = 30 + _backGrid.Width + c.GetCoordinate().GetX() * 26;
            initialY = 25 + c.GetCoordinate().GetY() * 26;
            DrawEllipse(g, initialX, initialY, c.GetPstate());
        }
    }
}
