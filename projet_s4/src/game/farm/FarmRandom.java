package game.farm;

import java.util.*;
import java.time.ZonedDateTime;

import game.Farm;
import game.farm.FarmUtils;
import game.utils.*;

public class FarmRandom {

    private static int currentTurn;

    public static int game(int nbTurnsMax, ArrayList<Player> players, Board board) {

        currentTurn = 1;
        int end = 0;
        System.out.println("---------------------------------------");
        while (nbTurnsMax >= currentTurn && end >= 0) {

            System.out.println("Turn " + currentTurn);
            board.printBoard();

            for (Player currentPlayer : players) {
                Random rng = new Random(ZonedDateTime.now().toInstant().toEpochMilli());

                // Firstly, print the current gold of the Player.
                System.out.println(currentPlayer.getName() + " has " + currentPlayer.getGold() + " Gold.");
                System.out.print('\n');

                // If rng decides that the player puts down an army
                if (rng.nextInt(100) <= 65) {
                    Case currentCase = board.getCase(rng.nextInt(board.getLength()), rng.nextInt(board.getWidth()));

                    while (currentCase.getType().equals(CaseType.OCEAN) || currentCase.getUsedState()) {
                        currentCase = board.getCase(rng.nextInt(board.getLength()), rng.nextInt(board.getWidth()));
                    }

                    System.out.println(currentPlayer.getName() + " decides to deploy a worker in " + currentCase.toString());
                    end = FarmUtils.workerDeploy(currentPlayer, currentCase, board);
                }

                else {
                    System.out.println(currentPlayer.getName() + " does nothing for this turn.");
                }

                // Converting resources.
                System.out.println(currentPlayer.getName() + " convert his resources earned with his workers.");
                FarmUtils.convertResources(currentPlayer, board);

                System.out.println(currentPlayer.getName() + " has now " + currentPlayer.getGold() + " Gold.");

                // Paying workers.
                System.out.println(currentPlayer.getName() + " had to pay his workers for their efforts.");
                FarmUtils.payWorkers(currentPlayer, board);

                System.out.println(currentPlayer.getName() + " has now " + currentPlayer.getGold() + " Gold.");

                System.out.print('\n');

            }

            System.out.println("---------------------------------------");
            currentTurn++;
        }

        currentTurn--;
        return currentTurn;
    }
}