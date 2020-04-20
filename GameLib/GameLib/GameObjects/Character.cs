using GameLib.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
   public class Character:GameObject
    {

        public int Strength, Dexterity;
        private double defense;

        public double Defense
        {
            get {
                double def = 0;
                if (Head != null)
                {
                    def += Head.Defense;
                }
                if (Chest != null)
                {
                    def += Chest.Defense;
                }
                return def+Dexterity/2;
                }           
                }

        private double attackDamage;

        public double AttackDamage
        {
            get {
                double atk = Strength;
                if (RightHand != null)
                {
                    if (Strength > RightHand.StrengthRequirement && Dexterity > RightHand.DexterityRequirement)
                    {
                        atk += RightHand.Damage;
                    }
                    else
                    {
                        atk += RightHand.Damage / 4;
                    }
                }
                if (LeftHand != null)
                {
                    if (Strength > LeftHand.StrengthRequirement && Dexterity > LeftHand.DexterityRequirement)
                    {
                        atk += LeftHand.Damage;
                    }
                
                    else
                    {
                        atk += LeftHand.Damage / 4;
                    }
                }

                return atk;


            }
           
        }





        List<IAction> Actions;

        List<Item> Inventory;

        

       public Helmet Head;
        public Weapon LeftHand,  RightHand;
        public Chest Chest;



        public Character(string name, string tag):base(name,tag)
        {
            Inventory = new List<Item>();
            Actions = new List<IAction>();
            Strength = 1;
            Dexterity = 1;

        }
        public override void Die()
        {
            foreach (var item in Inventory)
            {
                World.WorldInstance.Tiles[this.GetPosition()].Add(item);
            }
           
            base.Die();
        }
        public void PickUp(Item item)
        {
            Inventory.Add(item);
        }

        public void Equip(Weapon weapon, bool rightHand)
        {
            
            if (rightHand)
            {
                Inventory.Add(RightHand);
                RightHand = weapon;
            }
            else
 
            {
                Inventory.Add(LeftHand);
                LeftHand = weapon;
            }
        }
        
        public void Equip(Helmet helm)
        {
            Inventory.Add(Head);
            Head = helm;
        }

        public void Equip(Chest chest)
        {
            Inventory.Add(Chest);
            Chest = chest;
        }

        public void AddAction(IAction action)
        {
            Actions.Add(action);
        }

        public List<IAction> GetAllActions()
        {
            return Actions;
            
        }

        public void UseAction(IAction action, GameObject user, GameObject target)
        {
            action.Act(target);
         
        }
        public override void OnDamage(ref double hitpoints)
        {
            hitpoints -= Defense;
        }



    }
}
