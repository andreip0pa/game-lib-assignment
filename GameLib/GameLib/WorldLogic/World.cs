using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib
{

    //There can be a single world at a time
    public class World
    {


       public Dictionary<Position,Tile> Tiles;




        private static World instance;

        public static World WorldInstance
        {
            get {
                if (instance == null)
                {
                    instance = new World();
                }
                    return instance;
            }
            
        }
        public World()
        {
            Tiles = new Dictionary<Position, Tile>();
           
          

        }
        public void Add(GameObject gameObject)
        {
            int x = gameObject.GetPosition().x;
            int y = gameObject.GetPosition().y;

            Position pos = new Position(x, y);
            try
            {
                if (Tiles[pos] != null)
                {
                    Tiles[pos].Add(gameObject);
                }
                else
                {
                    Tile t = new Tile();
                    t.Add(gameObject);
                    Tiles.Add(pos, t);
                }
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Tile t = new Tile();
                t.Add(gameObject);
                Tiles.Add(pos, t);
            }
        }
        public void Add(GameObject gameObject, int x, int y)
        {
            gameObject.SetPosition(new Position(x,y));
            Add(gameObject);
        }

        public void Generate(int seed, int worldSize)
        {
            Tiles = new Dictionary<Position, Tile>();
            
            GameObjects.CharacterLibrary characterLibrary = new GameObjects.CharacterLibrary();
            List <Character> characterList= characterLibrary.GetAllCharacters();
            Random rand = new Random(seed);
            for (int i = 1; i <= worldSize; i++)
            {
                for (int j = 1; j <= worldSize; j++)
                {
                    Tile tile = new Tile();
                    Tiles.Add(new Position(i, j), tile);


                    int enemyChance = 10;
                    int crateChance = 10;

                    if (rand.Next(1, 100) <= enemyChance)
                    {
                        


                        tile.Add(characterLibrary.Characters[rand.Next(0, characterLibrary.Characters.Count - 1)]);

                    }

                    if (rand.Next(1, 100) <= crateChance)
                    {

                        Character crate = (from c in characterList where c.Name.Contains("Treasure") select c).First();
                        tile.Add(crate);
                    }

                }
            }

        }



    }
}
