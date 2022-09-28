package game.war;

import java.io.*;
import java.util.*;
import java.time.ZonedDateTime;
import game.utils.*;
import game.*;

public class WarNonRandom {

	private static int currentTurn;

	public static int game(int nbTurnsMax, ArrayList<Player> players, Board board, String playerName) {

		currentTurn = 1;
		int end = 0;
		System.out.println("---------------------------------------");
		while (nbTurnsMax >= currentTurn && end >= 0) {
			System.out.println("Turn " + currentTurn);
			Iterator<Player> iterator = players.iterator();
			while (iterator.hasNext() == true) {
				Player currentPlayer = iterator.next();

				if (playerName.equals(currentPlayer.getName())) {

				}

				else {
					Random rng = new Random(ZonedDateTime.now().toInstant().toEpochMilli());

					// If rng decides that the player puts down an army
					if (rng.nextInt(2) == 1) {
						Case currentCase = board.getCase(rng.nextInt(board.getLength()), rng.nextInt(board.getWidth()));
						while (currentCase.getType().equals(CaseType.OCEAN) == true || currentCase.getUsedState() == true) {
							currentCase = board.getCase(rng.nextInt(board.getLength()), rng.nextInt(board.getWidth()));
						}
						int armySize = rng.nextInt(Integer.min(currentPlayer.getUnits(), currentCase.getMaxCapacity()))+1;

						System.out.println(currentPlayer.getName() + " decides to put an army of " + armySize);
						end = WarUtils.armyDeploy(currentPlayer, armySize, currentCase, board);
					}

					else {
						System.out.println(currentPlayer.getName() + " does nothing for this turn.");
					}

					System.out.println(currentPlayer.getName() + " now goes to feed its armies.");
					WarUtils.feedArmies(currentPlayer, board);
			}
		}

			System.out.println("---------------------------------------");
			currentTurn++;
		}

		currentTurn--;
		return currentTurn;
	}
}