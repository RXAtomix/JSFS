using System;

namespace Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			grid g = new grid(5);
			info.print_score();
			g.print_grid();

			Controller c = new Controller();
			while (true)
			{
				switch (c.get_action())
				{
					case Controller.Action.Up:
						g.move_up();
						break;
					case Controller.Action.Down:
						g.move_down();
						break;
					case Controller.Action.Left:
						g.move_l();
						break;
					case Controller.Action.Right:
						g.move_r();
						break;
					default:
						break;
				}
					
				Console.Clear();
				info.print_score();
				g.print_grid();
			}
		
		}
	}
}
