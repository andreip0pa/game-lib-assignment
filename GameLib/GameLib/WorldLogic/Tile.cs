using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    public class Tile
    {
        List<GameObject> gameObjects;
        List<Item> items;

        public Tile()
        {
            gameObjects = new List<GameObject>();
            items = new List<Item>();
        }

        public void Add(GameObject target)
        {
            gameObjects.Add(target);
        }
        public void Add(Item target)
        {
            items.Add(target);
        }

        public void Remove(GameObject target)
        {
            gameObjects.Remove(target);
        }
        public void Remove(Item target)
        {
            items.Remove(target);
        }
        public List<GameObject> GetAllObjects()
        {
            
            return gameObjects;
        }
        public List<Item> GetAllItems()
        {
            return items;
        }


    }
}
