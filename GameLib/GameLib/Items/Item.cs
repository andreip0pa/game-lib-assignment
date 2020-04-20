using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GameLib.Items;
namespace GameLib
{
    public class Item
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        private bool consumable;

        public bool Consumable
        {
            get { return consumable; }
            set { consumable = value; }
        }




        public Item(string name, double value, double weight)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
            Weight = weight;
        }

        public static IEnumerable<Item> LoadItems()
        {

            Newtonsoft.Json.JsonSerializerSettings rule = new Newtonsoft.Json.JsonSerializerSettings();
            rule.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            List<Item> list = new List<Item>();
            StreamReader sr = new StreamReader("Items\\items.txt");
            string line;
                Item item=null;
            string text = sr.ReadToEnd();
            string[] lines = text.Split('*');
            string[] linesB=new string[lines.Length-1];
           for (int i = 0; i < lines.Length - 1; i++)
            {
                linesB[i] = lines[i];
            }
            foreach (string i in linesB)
            {



                try
                {

                    
                    item = Newtonsoft.Json.JsonConvert.DeserializeObject<Weapon>(i,rule);
                }
                catch
                {

                }
                
                {

                }
                try
                {
                    item = Newtonsoft.Json.JsonConvert.DeserializeObject<Helmet>(i,rule);
                }
                catch
                {

                }

                try
                {
                    item = Newtonsoft.Json.JsonConvert.DeserializeObject<Chest>(i,rule);
                }
                catch
                {

                }




                if (item == null)
                {
                    item = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(i,rule);
                }
                list.Add(item);
                item = null;
            }
            sr.Close();
            return list;



        }

        public static void AddItem(Item item)
        {
            Newtonsoft.Json.JsonSerializerSettings rule = new Newtonsoft.Json.JsonSerializerSettings();
            rule.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;


            List<Item> itemList = new List<Item>();
            itemList.Add(item);
            string converted = Newtonsoft.Json.JsonConvert.SerializeObject(item,rule);

            TextWriter sw = new StreamWriter("Items\\items.txt",true);
            sw.WriteLine(converted+"*");
            
           
            sw.Close();
           
        }

        public static void AddItem(Weapon item)
        {
            Newtonsoft.Json.JsonSerializerSettings rule = new Newtonsoft.Json.JsonSerializerSettings();
            rule.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            List<Item> itemList = new List<Item>();
            itemList.Add(item);
            string converted = Newtonsoft.Json.JsonConvert.SerializeObject(item,rule);

            TextWriter sw = new StreamWriter("Items\\items.txt", true);
            sw.WriteLine(converted + "*");


            sw.Close();

        }



    }
}
