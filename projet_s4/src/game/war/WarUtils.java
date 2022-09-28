package game.war;

import java.util.ArrayList;
import java.util.Random;
import game.*;
import game.utils.*;

public class WarUtils {

	/**	Deploys an army for the specified player with set size in the specified case
	 * @Return 0 if the army could be deployed, 1 otherwise, and -1 if all the cases have been used
	*/
	public static int armyDeploy(Player p, int size, Case boardCase, Board board) {

		// First, check if the case is already used
		if (boardCase.getUsedState()) {
			System.out.println(	"Error: Can't put army on case at position " +
													boardCase.getX() +
													" " +
													boardCase.getY() +
													".");
			return 1;
		}
		else {
			// If the army can be put in it
			boardCase.updateCapacity(size);
			boardCase.setPlayer(p);

			int armyPower = size;
			if (boardCase.getType().equals(CaseType.MOUNTAIN)) {
				armyPower += 2;
			}

			// Then check the surrounding armies
			checkOtherArmies(p, armyPower, boardCase, board);

			boolean end = true;
			for (int i = 0; i < board.getLength(); i++) {
				for (int j = 0; j < board.getWidth(); j++) {

					Case check = board.getCase(i, j);

					if (!check.getType().equals(CaseType.OCEAN) && !check.getUsedState()) {
						end = false;
					}
				}
			}
			if (end) {
				return -1;
			}
			return 0;
		}
	}

	public static void checkOtherArmies(Player p, int armyPower, Case boardCase, Board board) {

		// Get the current coordinates
		int caseX = boardCase.getX();
		int caseY = boardCase.getY();
		Case otherCase = null;

		// Then check the 4 surrounding cases: 2 on the same x axis, and 2 on the same y axis
		for (int i = -1; i <= 1; i+= 2) {

			// x axis first
			if (caseX + i >= 0 && caseX + i < board.getLength()-1) {

				// Get the properties of the case if it exists
				otherCase = board.getCase(caseX + i, caseY);
				int otherCaseArmySize = (5-otherCase.getCapacity());

				// Adding the type bonus if on a mountain
				if (otherCase.getType().equals(CaseType.MOUNTAIN)) {
					otherCaseArmySize += 2;
				}

				// Apply the correct behaviour is the case is occupied
				if (otherCase.getUsedState()) {
					if (otherCaseArmySize < armyPower) {
						if (!otherCase.getPlayer().equals(p)) {
							System.out.println("One of " + otherCase.getPlayer().getName() + " gets attacked!");
							int newSize = (5-otherCase.getCapacity())/2;
							if (newSize < 1) {
								System.out.println(otherCase.getPlayer().getName() + "'s army has been captured by " + p.getName());
								otherCase.setPlayer(p);
								boardCase.addGold(2);
							}
						}
						else if (otherCase.getPlayer().equals(p)) {
							System.out.println("One of " + p.getName() + "'s army has been reinforced.");
							otherCase.updateCapacity(1);
							boardCase.addGold(1);
						}
					}
				}
			}

			// Y axis now, with the same behaviour
			if (caseY + i >= 0 && caseY + i < board.getWidth()-1) {

				otherCase = board.getCase(caseX, caseY+i);
				int otherCaseArmySize = (5-otherCase.getCapacity());

				if (otherCase.getUsedState()) {
					if (otherCaseArmySize < armyPower) {
						if (!otherCase.getPlayer().equals(p)) {
							int newSize = (5-otherCase.getCapacity())/2;
							if (newSize < 1) {
								otherCase.setPlayer(p);
								boardCase.addGold(2);
							}
						}
						else if (otherCase.getPlayer().equals(p)) {
							otherCase.updateCapacity(1);
							boardCase.addGold(1);
						}
					}
				}
			}

		}
	}

	private static void convertToFood(Player p, Board board) {

		// Check each case one by one to see if it belongs to the right player
		Case check = null;

		for (int i = 0; i < board.getLength(); i++) {
			for (int j = 0; j < board.getWidth(); j++) {
				check = board.getCase(i, j);
				if (check.getPlayer() != null && check.getPlayer().equals(p)) {

					if (check.getType().equals(CaseType.PLAIN)) {
						p.addFood(5);
					}
					else if (check.getType().equals(CaseType.FOREST)) {
						p.addFood(1);
					}
				}
			}
		}
	}

	public static void feedArmies(Player p, Board board) {

		// First, convert all possible resources to food to maximise the amount of food
		convertToFood(p, board);

		// Check each case one by one to see if it belongs to the right player
		Case check = null;
		for (int i = 0; i < board.getLength(); i++) {
			for (int j = 0; j < board.getWidth(); j++) {
				check = board.getCase(i, j);
				if (check.getPlayer() != null && check.getPlayer().equals(p)) {

					// If it does belong to the right player
					int feedingCost = check.getCapacity();

					// Check if in the desert for twice the cost
					if (check.getType().equals(CaseType.DESERT)) {
						feedingCost *= 2;
					}

					if (p.getFood() >= feedingCost) {
						p.addFood(-feedingCost);
					}
					else {
						System.out.println(p.getName() + " can't feed one of its armies!");
						p.addGold(1);
						check.resetCase();
					}
				}
			}
		}
	}

}