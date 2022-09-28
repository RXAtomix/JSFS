package game.utils;

import java.util.Arrays;
import java.util.Random;
import java.time.ZonedDateTime;
import game.utils.Case;
import game.utils.CaseType;

public class Board {

	private int length;
	private int width;
	private Case[][] board;

	public Board(int length, int width, String gameMode) {
		this.length = length;
		this.width = width;
		int deux_tiers = (length * width) * 2/3;

		Random randomNumberlength = new Random(ZonedDateTime.now().toInstant().toEpochMilli());
		Random randomNumberwidth = new Random(ZonedDateTime.now().toInstant().toEpochMilli());

		board = new Case[length][width];
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++){
				board[i][j] = new Case(CaseType.OCEAN, i, j);
			}
		}
		int i = length * width;

		while (i > deux_tiers) {

			int case1length = randomNumberlength.nextInt(length);
			int case1width = randomNumberwidth.nextInt(width);
			Case case1 = board[case1length][case1width];

			// System.out.println("Case 1 length: " + case1length + ", width: " + case1width);

			if (case1.getType() == CaseType.OCEAN) {
				case1.setCaseType(CaseType.getRandomCaseNoOcean(), gameMode);
				i--;
			}
			else {
				continue;
			}

			int case2length = 0;
			int case2width = 0;

			// If case 1 is on the top edge
			if (case1length == 0) {

				// Case 2 is either on the top edge or next to it
				case2length = case1length + randomNumberlength.nextInt(2);

				// If it ends up on the edge
				if (case2length == 0) {

					// If the first case is in either corners
					if (case1width == 0) {
						case2width = 1;
					}
					else if (case1width == width-1) {
						case2width = case1width-1;
					}
					// Otherwise, we can use random to set it on one of the sides of the first case
					else {
						switch (randomNumberwidth.nextInt(2)) {
							case 0:	case2width = case1width-1; break;
							case 1: case2width = case1width+1; break;
							default: System.out.println("How did you even get here?"); break;
						}
					}
				}
				// If it's not on the edge, it has only one possible place
				else {
					case2width = case1width;
				}
			}

			// If case 1 is on the bottom edge
			else if (case1length == length-1) {

				// Same thing as with the top edge, but with -1 instead of 1
				case2length = case1length -(randomNumberlength.nextInt(2));

				// If it ends up on the edge
				if (case2length == length-1) {

					// If the first case is in either corners
					if (case1width == 0) {
						case2width = case1width+1;
					}
					else if (case1width == width-1) {
						case2width = case1width-1;
					}
					// Otherwise, we can use random to set it on one of the sides of the first case
					else {
						switch (randomNumberwidth.nextInt(2)) {
							case 0:		case2width = case1width-1; break;
							case 1: 	case2width = case1width+1; break;
							default: 	System.out.println("How did you even get here?"); break;
						}
					}
				}
				// If it's not on the edge, it has only one possible place
				else {
					case2width = case1width;
				}
			}

			// If case 1 is not on the edges
			else {
				switch (randomNumberlength.nextInt(3)) {
					// If rng puts the second case on the same line, generate the column randomly
					case 0:			case2length = case1length;
											if (case1width == 0) {
												case2width = case1width+1;
											}
											else if (case1width == width-1) {
												case2width = case1width-1;
											}
											else {
												switch (randomNumberwidth.nextInt(2)) {
												case 0:	case2width = case1width-1; break;
												case 1: case2width = case1width+1; break;
												default: System.out.println("How did you even get here?"); break;
											}
										}
										break;
					case 1:		case2length = case1length-1;
										case2width = case1width;
										break;
					case 2:		case2length = case1length+1;
										case2width = case1width;
										break;
					default:	System.out.println("How?");

				}
			}

			// System.out.println("Case 2 length: " + case2length + ", width: " + case2width);
			Case case2 = board[case2length][case2width];

			if (case2.getType() == CaseType.OCEAN) {
				case2.setCaseType(CaseType.getRandomCaseNoOcean(), gameMode);
				i--;
			}
			else {
				continue;
			}
		}
	}

	public int getLength(){
		return this.length;
	}

	public int getWidth(){
		return this.width;
	}

	public Case getCase(int x, int y){
		return this.board[x][y];
	}

	public boolean equals(Object o){
		if (o instanceof Board) {
			Board other = (Board) o;
	return (this.length == other.length) && (this.width ==  other.width) && this.board.equals(other.board);
	}
	else{
		return false;
		}
	}

	public String toString1(){
		return Arrays.toString(this.board);
	}

	public void printBoard() {
		System.out.println("Board :");
		System.out.println("First letter is the case type (Forest, Ocean, Mountain, Desert, or Plain).");
		System.out.println("Second letter indicates if the case is Occupied or Empty\n");


		for (int i = 0; i < this.length; i++) {
			System.out.print(i + " |");
			for (int j = 0; j < this.width; j++) {
				String currentCaseType = switch (this.board[i][j].getType()) {
					case OCEAN -> " O ";
					case MOUNTAIN -> " M ";
					case DESERT -> " D ";
					case FOREST -> " F ";
					case PLAIN -> " P ";
					default -> "";
				};

				if (this.board[i][j].getUsedState()) {
					currentCaseType += "O";
				}

				else {
					currentCaseType += "E";
				}

				System.out.print(currentCaseType + " |");
			}
			System.out.print("\n");
		}
		System.out.println("\n");
	}
}