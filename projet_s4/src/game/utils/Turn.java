package game.utils;

import java.util.Iterator;

public class Turn {

    public static void endGame(Iterator<Player> players, Board board, String type) {
        int maxScore = 0;

        Player winningPlayer = null;

        while (players.hasNext()) {
            Player currentPlayer = players.next();

            int score = currentPlayer.getGold();
            Case check = null;

            for (int i = 0; i < board.getLength(); i++) {
                for (int j = 0; j < board.getWidth(); j++) {
                    check = board.getCase(i, j);
                    if (!check.getType().equals(CaseType.OCEAN) && check.getPlayer() != null) {
                        if (check.getPlayer().equals(currentPlayer)) {
                            score += check.getGold();
                        }
                    }
                }
            }

            if (score >= maxScore) {
                maxScore = score;
                winningPlayer = currentPlayer;
            }
        }

        int nbTurns = 0;

        if (type == "Farm"){
            nbTurns = 6;
        }

        if (type == "War"){
            nbTurns = 10;
        }

        System.out.println("Player " + winningPlayer.getName() + " wins with " + maxScore + " points after " + nbTurns + " turns.");

        System.exit(0);
    }

}
