using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
	public class Shop
	{
        public List<Item> ItemsForSale{ get; set; }
        public int ID{ get; set; }
        public string Name{ get; set; }
        public double PriceModifier{ get; private set; }

        public Shop (string name, int id)
		{
            Name = name;
            ID = id;
            PriceModifier = 1;
			ItemsForSale = new List<Item>();

		}

        public void UpdatePriceModifier(int securityLevel)
        {
            switch(securityLevel)
            {
                case 10:
                    PriceModifier = 1;
                    break;
                case 9:
                    PriceModifier = .98;
                    break;
                case 8:
                    PriceModifier = .96;
                    break;
                case 7:
                    PriceModifier = .94;
                    break;
                case 6:
                    PriceModifier = .92;
                    break;
                case 5:
                    PriceModifier = .90;
                    break;
                case 4:
                    PriceModifier = .88;
                    break;
                case 3:
                    PriceModifier = .86;
                    break;
                case 2:
                    PriceModifier = .84;
                    break;
                case 1:
                    PriceModifier = .82;
                    break;
                case 0:
                    PriceModifier = .75;
                    break;
                default:
                    PriceModifier = 1;
                    break;
            }
        }

        public int GetItemPriceByID(int id)
        {
            return (int)(ItemsForSale.SingleOrDefault(x => x.ID == id).Value * PriceModifier);
        }
	}
}

