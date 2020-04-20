using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


namespace GameLib
{
   public class Weapon : Item
    {
        private double damage;

        public double Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int strReq;

        public int StrengthRequirement
        {
            get { return strReq; }
            set { strReq = value; }
        }

        private int dexReq;

        public int DexterityRequirement
        {
            get { return dexReq; }
            set { dexReq = value; }
        }



        
        
        public Weapon(string name, double weight, double value):base(name,value,weight)
        {

        }
        public Weapon(string name, double weight, double value, double damage):base(name,value,weight)
        {
            Damage = damage;
        }

        [Newtonsoft.Json.JsonConstructor]
        public Weapon(string name, double weight, double value, double damage, int strReq, int dexReq) :base(name,value,weight)
        {
            
            Damage = damage;
            StrengthRequirement = strReq;
            DexterityRequirement = dexReq;
        }

       
    }
}
