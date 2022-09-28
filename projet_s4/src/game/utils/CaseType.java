package game.utils;
import java.util.Random;
import java.lang.reflect.Array;

/*  The enumeration of the differents availables case types for the board.
    They are, in order: Desert, Forest, Plain, Mountain, and Ocean.
*/
public enum CaseType {
    DESERT, FOREST, PLAIN, MOUNTAIN, OCEAN;

    private static final CaseType[] CASES = values();
    private static final int SIZE = CASES.length;
    private static final Random RANDOM = new Random();

    // Returns a random case type
    public static CaseType getRandomCase() {
    	return CASES[RANDOM.nextInt(SIZE)];
    }

    // Returns a random case type, excluding the last one in the list.
    public static CaseType getRandomCaseNoOcean() {
    	return CASES[RANDOM.nextInt(SIZE-1)];
    }
}