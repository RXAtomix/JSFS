using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimCity
{
    /// <summary>
    /// Enumeration containing all the types of building
    /// </summary>
    enum BuildingType
    {
        House = 0,
        CityHall,
        PoliceStation,
		Factory,
		Shop
    }

    abstract class Building
    {
        public int Health { get; set; }
        public BuildingType Type { get; protected set; }

        public abstract void Print();
    }
}
