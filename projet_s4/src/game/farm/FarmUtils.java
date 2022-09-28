package game.farm;
import game.utils.*;

public class FarmUtils {

    /**	Deploys a worker for the specified player with set size in the specified case
     * @Returns 0 if the worker could be deployed, 1 otherwise, and -1 if all the cases have been used.
     * */
    public static int workerDeploy(Player p, Case boardCase, Board board){

        // Checking if the case is already used
        if (boardCase.getUsedState()){
            System.out.println("You can't put a worker here. (Position " +
                                boardCase.getX() + " " +
                                boardCase.getY() + ").");
            return 1;
        }

        else {
            // If the case is not used, we can proceed
            boardCase.setPlayer(p);
            boardCase.setUsed();

            boolean end = true;

            for (int i = 0; i < board.getLength(); i++){
                for (int j = 0; j < board.getWidth(); j++ ){

                    Case check = board.getCase(i, j);

                    if (!check.getType().equals(CaseType.OCEAN) && !check.getUsedState()){
                        end = false;
                    }
                }
            }

            if (end){
                return -1;
            }

            return 0;
        }
    }


    /** Convert the resources to gold.
     * @param p the Player.
     * @param board the Board.
     */
    public static void convertResources(Player p, Board board){

        Case check = null;

        for (int i = 0; i < board.getLength(); i++){
            for (int j = 0; j < board.getWidth(); j++){
                check = board.getCase(i, j);

                if (check.getPlayer() != null && check.getPlayer().equals(p)){

                    if (check.getType().equals(CaseType.MOUNTAIN)){
                        p.addGold(8);

                    }

                    if (check.getType().equals(CaseType.DESERT)){
                        p.addGold(5);
                    }

                    if (check.getType().equals(CaseType.PLAIN)){
                        p.addGold(2);
                    }

                    if (check.getType().equals(CaseType.FOREST)){
                        p.addGold(2);
                    }

                }
            }
        }
    }


    /** Pay the workers.
     * @param p a Player.
     * @param board the Board.
     * */
    public static void payWorkers(Player p, Board board){

        Case check = null;

        for (int i = 0; i < board.getLength(); i++){
            for (int j = 0; j < board.getWidth(); j++){
                check = board.getCase(i, j);
                if (check.getPlayer() != null && check.getPlayer().equals(p)){

                    if (p.getGold() <= 0){
                        System.out.println(p.getName() + " can't pay his worker.");
                        check.resetCase();
                    }

                    if (check.getType().equals(CaseType.MOUNTAIN)){
                        p.addGold(-5);
                    }

                    if (check.getType().equals(CaseType.DESERT)){
                        p.addGold(-2);
                    }

                    if (check.getType().equals(CaseType.PLAIN)){
                        p.addGold(-1);
                    }

                    if (check.getType().equals(CaseType.FOREST)){
                        p.addGold(-1);
                    }

                }
            }
        }

    }

}
