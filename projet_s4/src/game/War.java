package game;

import java.util.*;
import java.time.ZonedDateTime;
import game.utils.*;
import game.war.*;

public class War {

	public ArrayList<Player> players;
	private int nbTurnsMax, lastTurn;
	private int randomPlay;
	private Board board;

	public static void main(String[] args) {
		War game = new War();
		game.setup(args);
	}

	private void setup(String[] args) {

		if (args.length < 1) {
			System.out.println("Please add the name of players before lauching the application.");
			System.exit(1);
		}

		System.out.println("Welcome to the War game !");


		// Sets up the player list
		this.players = new ArrayList<Player>();
		for (int i = 0; i < args.length; i++) {
			System.out.println("Player " + i + ": " + args[i]);
			if (!this.players.add(new Player(args[i], "War"))) {
				System.out.println("Error: Player named " + args[i] + " already registered.");
			}
		}

		try {
			int boardSize = PlayerInteraction.selectBoard();
			this.board = new Board(boardSize, boardSize, "War");

			int autoPlay = PlayerInteraction.selectAutoPlay(this.players.get(0).getName());
			if (autoPlay == 1) {
				this.lastTurn = WarRandom.game(10, this.players, this.board);
			}
			else if (autoPlay == 2) {
				this.lastTurn = WarNonRandom.game(10, this.players, this.board, this.players.get(0).getName());
			}
		}
		catch (Exception e) {
			System.out.println("Error while trying to use player interaction! Defaulting to base settings for board and player input for the game...");
			this.board = new Board(10, 10, "War");
			this.lastTurn = WarRandom.game(10, this.players, this.board);
		}


		Iterator<Player> iterator = this.players.iterator();

		Turn.endGame(iterator, this.board, "War");
	}
}