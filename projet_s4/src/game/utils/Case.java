package game.utils;

/*	The type handling the cases for the board
		It defines its type, its x and y coordinates, and the capacity of the case
*/
public class Case {

	private CaseType type;
	private String gameMode;
	private final int x, y;
	private int capacity, maxCapacity;
	private boolean used;
	private Player player;
	private int gold;

	public Case(CaseType type, int x, int y) {
		setCaseType(type, "noMode");
		this.x = x;
		this.y = y;
		this.used = false;
		this.player = null;
		this.gold = 0;
		this.capacity = 0;
	}

	public CaseType getType() {
		return this.type;
	}

	public void setCaseType(CaseType type, String gameMode) {
		this.type = type;
		this.gameMode = gameMode;
		switch (gameMode) {

			case "War":
			case "war":	if (this.type.equals(CaseType.DESERT) || this.type.equals(CaseType.MOUNTAIN)) {
										this.maxCapacity = 3;
									}
									else {
										this.maxCapacity = 5;
									}
									break;

			case "Farm":
			case "farm":
									this.maxCapacity = 1;
									break;

			default:		this.maxCapacity = 0;
									break;
		}
	}

	public int getX() {
		return this.x;
	}

	public int getY() {
		return this.y;
	}

	public int getCapacity() {
		return this.capacity;
	}

	public int getMaxCapacity() {
		return this.maxCapacity;
	}

	public int updateCapacity(int nbUnits) {
		if (this.capacity + nbUnits > this.maxCapacity) {
			return -1;
		}
		else {
			this.capacity += nbUnits;
			this.used = true;
			return this.capacity;
		}
	}

	public boolean getUsedState() {
		return this.used;
	}

	public void setUsed(){
		this.used = !this.used;
	}

	public void resetCase() {
		setCaseType(this.type, this.gameMode);
		this.capacity = 0;
		this.used = false;
		this.player = null;
	}

	public void setPlayer(Player player) {
		this.player = player;
	}

	public Player getPlayer() {
		return this.player;
	}

	public int getGold() {
		return this.gold;
	}

	public void addGold(int added) {
		this.gold += added;
	}

	public String toString(){
		return "Case " + this.x + this.y + ".";
	}
}