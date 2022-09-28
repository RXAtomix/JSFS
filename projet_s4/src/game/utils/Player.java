package game.utils;

import java.util.Iterator;

public class Player {

	private String name;
	private int gold;
	private int units;
	private int food;

	public Player(String name, String gameType) {
		switch (gameType) {
			case "war":
			case "War":		this.gold = 0;
										this.units = 35;
										this.food = 10;
										break;

			case "farm":
			case "Farm":	this.gold = 15;
										this.units = 0;
										this.food = 0;
										break;

			default:			this.food = this.units = this.gold = 0;
		}
		this.name = name;
	}

	public String getName() {
		return this.name;
	}

	public void addGold(int goldAdded) {
		this.gold += goldAdded;
	}

	public int getGold() {
		return this.gold;
	}

	public boolean equals(Object o) {
		if (!(o instanceof Player)) {
			return false;
		}
		else {
			Player other = (Player) o;

			if (this.name.equals(other.getName()) && this.gold == other.getGold()) {
				return true;
			}
			else {
				return false;
			}
		}
	}

	public void addFood(int foodAdded) {
		this.food += foodAdded;
	}

	public int getFood() {
		return this.food;
	}

	public void addUnits(int unitsAdded) {
		this.units += unitsAdded;
	}

	public int getUnits() {
		return this.units;
	}

}