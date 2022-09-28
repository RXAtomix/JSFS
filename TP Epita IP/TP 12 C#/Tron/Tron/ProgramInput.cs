using System;
using System.Diagnostics;
using System.Threading;

namespace Tron
{
	public class ProgramInput : Input
	{

		public Action NextAction { get; set; }
		Process process;
		Map map;
		bool error = false;
		int timeout;

		~ProgramInput()
		{
			process.Kill();
		}

		public ProgramInput(string name, Map map, int x, int y, int timeout)
		{
			ProcessStartInfo info = new ProcessStartInfo(name);

			this.timeout = timeout;
			this.map = map;

			info.UseShellExecute = false;
			info.RedirectStandardOutput = true;
			info.RedirectStandardInput = true;
			try
			{
				process = Process.Start(info);
				process.StandardInput.WriteLine(map.Height
												+ " " + map.Width);
				process.StandardInput.WriteLine(x + " " + y);
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.Message);
			}
		}

		void RunThread()
		{
			try
			{
				process.StandardInput.WriteLine(map.players.Count);
				foreach (var it in map.players)
				{
					process.StandardInput.WriteLine(it.x + " " + it.y);
				}

				string line = process.StandardOutput.ReadLine();
				switch (line)
				{
					case "L":
						NextAction = Action.left;
						error = false;
						break;
					case "R":
						NextAction = Action.right;
						error = false;
						break;
					case "U":
						NextAction = Action.up;
						error = false;
						break;
					case "D":
						NextAction = Action.down;
						error = false;
						break;
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.Message);
			}
		}

		public override Action GetNextAction()
		{
			try
			{
				error = true;
				Thread thread = new Thread(this.RunThread);
				thread.Start();
				thread.Join(timeout);
				if (error)
					process.Kill();
				return NextAction;
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e);
				return NextAction;
			}
		}
	}
}
