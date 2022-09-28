package game.utils;

import java.io.*;
import java.lang.*;

public class PlayerInteraction {

	private static final BufferedReader in = new BufferedReader(new InputStreamReader(System.in));

	public static int selectBoard() throws IOException {

		System.out.println("Do you want to choose the board size or go with the standard 10x10?\nType y if you want to choose, type n otherwise.\nInput:");
		String answer = in.readLine();
		String inputCheck = "yYnN";
		while (inputCheck.contains(answer) == false) {
			switch (answer) {
				case "Y":
				case "y":	int size = 0;
									while (size <= 0) {
										System.out.println("Please enter the size of one side of the square board.\nInput: ");
										try {
											size = Integer.parseInt(in.readLine());
											System.out.println("Size selected: " + size + "x" + size);
											return size;
										}
										catch (Exception e) {
											System.out.println("Input not readable. Pleaser enter a number.");
										}
									}
									break;

				case "n":
				case "N":	System.out.println("Size selected: 10x10.");
									break;

				default:	System.out.println("Input not recognized. Please enter y or n.");
									answer = in.readLine();
			}
		}
		return 10;
	}

	public static int selectAutoPlay(String playerName) throws IOException {

		// Asks the player if they want a full random game, or if they want to control the first player
		System.out.println("To have the computer play randomly, type 1.\nTo play as the first player, type 2.\nTo exit the application, type 3.\nInput: ");
		int input = 0;
		// And keep trying until we have a correct answer, or until we get an IOException from the reader
		while (input != 1 && input != 2 && input != 3) {
			try {
				input = Integer.parseInt(in.readLine());
			}
			catch(Exception e) {
				System.out.println("Error while reading the standard input. Please restart the application.");
				System.exit(1);
			}
			switch (input) {
				case 1:	System.out.println("Random play selected.");
								break;
				case 2: System.out.println("Player input selected. You will be playing as player one, named " + playerName + ".");
								break;
				case 3: System.exit(0);
								break;
			}
		}
		return input;
	}
}