using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
   public class Game
    {
        private string gameName;
        Character player;
        public string GameName
        {
            get { return gameName; }
            set { gameName = value; }
        }

        public Game(string name)
            
        {
            GameName = name;
            Start();
            while (true)
            {
               
                GameLoop();
              
                
            }


        }

        public void Start()
        {
            GameObjects.CharacterLibrary cl = new GameObjects.CharacterLibrary();
            player = cl.Characters[0];
            player.Tag = "player";
            
            Console.WriteLine("Welcome to " + GameName + " Demo! Do you wish to start? Type 'Yes' to start or 'No' to quit.");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                Console.WriteLine("Would you like to generate a new world or make your own?");
                Console.WriteLine("1.Generate a new world.");
                Console.WriteLine("2.Make my own.");

                response = Console.ReadLine();
                if (response == "1")
                {
                    Console.WriteLine("Input a seed.");
                    response = Console.ReadLine();
                    int seed = Convert.ToInt32(response);

                    World.WorldInstance.Generate(seed, 50);
                   
                    player.SetPosition(new Position(1, 1));


                }
                else if (response == "2")
                {

                }

            }


        }

        public void GameLoop()
        {
            bool combat = false;
            bool itemDrop = false;
            Tile currentTile = new Tile();

             currentTile = World.WorldInstance.Tiles[new Position(1, 1)];

             World.WorldInstance.Tiles.TryGetValue(player.GetPosition(), out currentTile);
            World.WorldInstance.Tiles[player.GetPosition()].Add(player);
            if (currentTile.GetAllObjects().Count == 1)
            {
                Console.WriteLine("There is no danger here(" + player.GetPosition().x + "," + player.GetPosition().y + ") " + ". What do you want to do?");
            }
            else
            if (currentTile.GetAllObjects().Count >= 2)
            {
                foreach (var item in currentTile.GetAllObjects())
                {
                    if (item.Tag != player.Tag)
                    Console.WriteLine("There is a " + item.Name + " here! It has +" + item.Hitpoints + " Health");
                }
                
                combat = true;
            }
            if (currentTile.GetAllItems().Count >= 1)
            {
                itemDrop = true;
                //foreach (var item in currentTile.GetAllItems())
                //{
                //    Console.WriteLine("You found a " + item);
                //}
            }
            while (combat)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1.Attack"); 
                Console.WriteLine("2.Run away");
                int choice =Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("You engage in combat against:");
                    foreach (var item in currentTile.GetAllObjects())
                    {   if (item.Tag!="player")
                        Console.WriteLine(item.Name+" with "+item.Hitpoints+" health.");
                    }
                    Console.WriteLine("Who do you want to attack?");
                    int enemyNumber = currentTile.GetAllObjects().Count;
                    for (int i = 0; i < currentTile.GetAllObjects().Count; i++)
                    {
                        Console.WriteLine((i+1)+"."+currentTile.GetAllObjects()[i]);
                    }
                    choice = Convert.ToInt32(Console.ReadLine());
                    GameObject enemy = currentTile.GetAllObjects()[choice - 1];
                    int c = 1;
                    Console.WriteLine("Which attack do you want to use?");
                    foreach (var item in player.GetAllActions().FindAll(x=>x.GetType()==typeof(Attack)))
                    {
                        Console.WriteLine(c+" "+item.Name);
                        c++;
                    }
                    choice = Convert.ToInt32(Console.ReadLine());
                    Attack attack =(Attack)player.GetAllActions()[choice - 1];
                    double hp = enemy.Hitpoints;
                    player.UseAction(attack, player, enemy);
                    
                    Console.WriteLine("You dealt "+(hp-enemy.Hitpoints)+" damage!");
                    if (enemy.Hitpoints <= 0)
                    {
                        Console.WriteLine("It died!");
                    }
                    Console.Read();


                }



            }
            if (itemDrop)
            {
                Console.WriteLine("1.Loot");
                Console.WriteLine("2.Move");

            }
            

            


            //

                //
        }


    }
}
