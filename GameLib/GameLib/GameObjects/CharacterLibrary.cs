using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.GameObjects
{
    class CharacterLibrary
    {
        private List<Character> characters;

        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        public CharacterLibrary()
        {
            Characters = new List<Character>();
            //HARDCODED CHARACTERS
            Character knight = new Character("Knight", "human");
            knight.Strength = 10;
            knight.Dexterity = 5;
            knight.Hitpoints = 50;
            Weapon knightSword = new Weapon("Knight Sword", 20, 300, 12, 9, 4);
            Items.Helmet knightHelmet = new Items.Helmet("Knight Helmet", 300, 20, 20);
            Items.Chest knightChest = new Items.Chest("Knight Chestplate", 500, 50, 40);
            knight.Head = knightHelmet;
            knight.RightHand = knightSword;
            knight.Chest = knightChest;

            Attack knightAttack = new Attack("Swing weapons");
            Attack knightAttack2 = new Attack("Stressing attack");

            knightAttack.Damage = knight.AttackDamage;
            knightAttack2.Damage = knight.AttackDamage * 1.5;
            
            knight.AddAction(knightAttack);
            knight.AddAction(knightAttack2);


            Character skeleton = new Character("Skeleton", "undead");
            skeleton.Strength = 7;
            skeleton.Dexterity = 9;
            skeleton.Hitpoints = 10;
            Weapon skeletonSword = new Weapon("Skeleton Sword", 20, 300, 5, 3, 3);
            Items.Helmet skeletonHelmet = new Items.Helmet("Skeleton Helmet", 300, 20, 20);
           
            skeleton.Head = skeletonHelmet;
            skeleton.RightHand =skeletonSword;
            

            Attack skeletonAttack = new Attack("Skeleton swing");
            Attack skeletonAttack2 = new Attack("Skeleton undead swing");
            Attack skeletonAttack3 = new Attack("Skeleton Rage swing"); 

            skeletonAttack.Damage = skeleton.AttackDamage*1.1;
            skeletonAttack2.Damage = skeleton.AttackDamage * DateTime.Now.Second%5;
            skeletonAttack3.Damage = skeleton.AttackDamage * (skeleton.MaxHitpoints - skeleton.Hitpoints) % 10;

            skeleton.AddAction(skeletonAttack);
            skeleton.AddAction(skeletonAttack2);
            skeleton.AddAction(skeletonAttack3);

            Character treasure = new Character("Treasure Crate", "crate");
            List<Item> items=(List<Item>)Item.LoadItems();
            treasure.PickUp(items[DateTime.Now.Millisecond % (items.Count - 1)]);

            Characters.Add(skeleton);
            Characters.Add(knight);
            characters.Add(treasure);



            //
        }

        public List<Character> GetAllCharacters()
        {
            return Characters;
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }


    }
}
