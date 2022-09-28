using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
    class Town
    {
        private List<Building> buildings;
        private int money;
        private int population;
        private int houseCount;
        private int hometownCount;
        private int policeCount;
		private int factoryCount;
		private int shopCount;

        // House, Hometown, Police Station
        private static int[] buildingPrices = { 1500, 10000, 5000, 7000, 2000 };

        public Town()
        {
            this.buildings = new List<Building>();
            this.money = 20000;
            this.population = 0;
            this.houseCount = 0;
            this.hometownCount = 0;
            this.policeCount = 0;
			this.factoryCount = 0;
			this.shopCount = 0;
        }

        public bool AddBuilding()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current money: {0}$", this.money);
            Console.ResetColor();
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("{0}: {1} | {2}$", i, (BuildingType)i, 
                    buildingPrices[i]);
            }


            Console.Write("Which building do you want to buy ?: ");
			int idx = 0;

			// Loop in order to prevent incorrect results
			while (true)
			{
				string input = Console.ReadLine();
				try
				{
					idx = Int32.Parse(input);
					if (idx < 0 || idx > 4)
						throw new Exception();
					break;
				}
				catch
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("Incorrect input, please choose again: ");
					Console.ResetColor();
				}
			}

            try
            {

                if (this.money < buildingPrices[idx])
                    return false;

                switch (idx)
                {
                    case 0:
                        this.buildings.Add(new House());
                        this.houseCount++;
                        break;
                    case 1:
                        this.buildings.Add(new CityHall());
                        this.hometownCount++;
                        break;
                    case 2:
                        this.buildings.Add(new PoliceStation());
                        this.policeCount++;
                        break;
					case 3:
						this.buildings.Add(new Factory());
						this.factoryCount++;
						break;
					case 4:
						this.buildings.Add(new Shop());
						this.shopCount++;
						break;
                    default:
                        return false;
                }

                this.money -= buildingPrices[idx];
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DestroyBuilding()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current money: {0}$", this.money);
            Console.ResetColor();
            int i = 0;
            foreach (Building b in this.buildings)
            {
                Console.WriteLine("{0}: {1} | +{2}$", i++, (BuildingType) b.Type, buildingPrices[(int) b.Type] / 2);
            }

            Console.WriteLine("Which building do you want to destroy ?: ");
            string input = Console.ReadLine();
            try
            {
                int idx = Int32.Parse(input);
                int gain = buildingPrices[(int) this.buildings[idx].Type];
                this.buildings.RemoveAt(idx);
                this.money += gain;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void PrintBuildings()
        {
            Console.Clear();
            foreach (Building b in buildings)
            {
                b.Print();
            }
            Console.SetCursorPosition(0, Console.CursorTop + CityHall.HOMETOWN_HEIGHT);
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

        public void PrintState()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current money: {0}$", this.money);
            Console.WriteLine("Number of buildings: {0}", this.buildings.Count);
            Console.WriteLine("Population: {0}", this.population);
            Console.ResetColor();
        }

        public void Update()
        {
            this.money += 100 + 10 * shopCount;
			this.money -= policeCount * 30;

			int popCapacity = 30 * houseCount;
			int jobCapacity = 100 * factoryCount + 20 * policeCount + 5 * shopCount;
			int criminality = population * 30 / 100 - policeCount * 80;

			if (popCapacity > population && jobCapacity > population && criminality < population * 15 / 100)
			{
				this.population += 10;
			}
        }
    }
}
