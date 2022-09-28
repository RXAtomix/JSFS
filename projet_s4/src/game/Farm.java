package game;

import java.io.IOException;
import java.util.*;
import java.util.concurrent.ExecutionException;

import game.utils.*;
import game.farm.*;
import game.war.WarNonRandom;
import game.war.WarRandom;

public class Farm {

    public ArrayList<Player> players;
    private int nbTurnsMax, lastTurn;
    private int randomPlay;
    private Board board;

    public static void main(String [] args){
        Farm game = new Farm();
        game.setup(args);
    }

    private void setup(String[] args){

        if (args.length < 1){
            System.out.println("\"Please add the name of players before lauching the application.");
            System.exit(1);
        }


        System.out.println("Welcome to the Farm game !");

        // Sets up the player list
        this.players = new ArrayList<Player>();

        for (int i = 0; i < args.length; i++){
            System.out.println("Player " + (i + 1) + ": " + args[i]);
            if (!this.players.add(new Player(args[i], "Farm"))){
                System.out.println("Error: Player named " + args[i] + " already registered.");
            }
        }

        try {
            int boardSize = PlayerInteraction.selectBoard();
            this.board = new Board(boardSize, boardSize, "Farm");

            int autoPlay = PlayerInteraction.selectAutoPlay(this.players.get(0).getName());
            if (autoPlay == 1) {
                this.lastTurn = FarmRandom.game(6, this.players, this.board);
            } else if (autoPlay == 2) {
                this.lastTurn = FarmRandom.game(6, this.players, this.board);
            }
        }
        catch (Exception e){
            System.out.println("Error while trying to use player interaction ! Defaulting to the base settings for board and player input for the game.");
            this.board = new Board(10, 10, "Farm");
            this.lastTurn = FarmRandom.game(6, this.players, this.board);
        }

        Iterator<Player> iterator = this.players.iterator();

        Turn.endGame(iterator, this.board, "Farm");
    }

}
