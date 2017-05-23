using System;

namespace Engine
{
    public class Item
    {
        public string Name{ get; set; }
        public string NamePlural{ get; set; }
		public int ID{ get; set; }
		public int Value{ get; set;}
        public int Volume{ get; set; }

		public Item(string name, string namePlural, int id, int value, int volume = 1)
		{
			Name = name;
			NamePlural = namePlural;
			ID = id;
			Value = value;
            Volume = volume;
		}
    }
}