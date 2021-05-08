using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Item: ICloneable
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool pickupable { get; set; }
        public int weight { get; set; }

        public object Clone()
        {
            return new Item();
        }
    }
}

