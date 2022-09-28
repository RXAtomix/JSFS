using System;

namespace TP13
{
	public class AI
	{
		Map map;

		public AI(Map map)
		{
			this.map = map;
		}

		int markDistance(int[,] marks, int x, int y, int depth)
		{
			if (x < 0 || x >= map.Width
				|| y < 0 || y >= map.Height
				|| marks[x, y] <= depth
				|| (depth > 1 && map.Walls[x, y]))
				return 0;
			bool newmark = marks[x, y] == Int32.MaxValue;
			marks[x, y] = depth;
			return (newmark ? 1 : 0)
				+ markDistance(marks, x + 1, y, depth + 1)
				+ markDistance(marks, x - 1, y, depth + 1)
				+ markDistance(marks, x, y + 1, depth + 1)
				+ markDistance(marks, x, y - 1, depth + 1);
		}

		public float Evaluation()
		{
			int[,] marksSelf = new int[map.Width, map.Height];
			int[,] marksEnnemy = new int[map.Width, map.Height];
			for (int i = 0; i < map.Width; i++)
			{
				for (int j = 0; j < map.Height; j++)
				{
					marksSelf[i, j] = Int32.MaxValue;
					marksEnnemy[i, j] = Int32.MaxValue;
				}
			}
			int availableSelf = markDistance(marksSelf, map.Self.x, map.Self.y, 1);
			int availableEnnemy = 0;
			if (map.Others.Count > 0)
				availableEnnemy = markDistance(marksEnnemy, map.Others[0].x, map.Others[0].y, 1);
			int score = 0;
			for (int i = 0; i < map.Width; i++)
			{
				for (int j = 0; j < map.Height; j++)
				{
					if (marksSelf[i, j] < marksEnnemy[i, j])
						score++;
					else if (marksEnnemy[i, j] < marksSelf[i, j])
						score--;
				}
			}
			return 10 * score + 10000 * (availableSelf - availableEnnemy);
		}





    // Ignore changes in the prototype, that was written before
    // changes in the subject
		Tuple<float, Map.Action> Minimax(int maxDepth, float alpha, float beta, bool ownTurn)
		{
			if (maxDepth <= 0)
				return new Tuple<float, Map.Action>(Evaluation(), Map.Action.up);
			Map.Action[] possibleActions = {Map.Action.up,
				Map.Action.down,
				Map.Action.left,
				Map.Action.right};
			float bestScore = ownTurn ? float.MinValue : float.MaxValue;
			Map.Action bestAction = Map.Action.up;
			bool validMove = false;
			foreach (Map.Action a in possibleActions)
			{
				Map oldMap = map;
				map = map.Clone();
        Player p = ownTurn ? map.Self : map.Others[0];

				if (p.MoveTo(map, a))
				{
					float newScore = Minimax(maxDepth - 1, alpha, beta, !ownTurn).Item1;
					if (!validMove || newScore > bestScore == ownTurn)
					{
						validMove = true;
						if (newScore > alpha && ownTurn)
							alpha = newScore;
						else if (newScore < beta && !ownTurn)
							beta = newScore;
						bestScore = newScore;
						bestAction = a;
					}
				}
				map = oldMap;
				if (alpha >= beta)
					break;
			}
			return new Tuple<float, Map.Action>(bestScore, bestAction);
		}






		public Map.Action GetNextAction()
		{
			float alpha = float.MinValue, beta = float.MaxValue;
			var ret = Minimax(1, alpha, beta, true);
			return ret.Item2;
		}
	}
}
