﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Items
{
   public class Helmet : Item
    {
    
        private double defense;

        public double Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public Helmet(string name, double value, double weight):base(name,value,weight)
        {

        }
        [Newtonsoft.Json.JsonConstructor]
        public Helmet(string name, double value, double weight, double defense) : base(name, value, weight)
        {
            Defense = defense;
        }
    }
}
