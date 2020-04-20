using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    
    /// <summary>
    /// Represents any type of entity that could be in the world.
    /// </summary>
  public  class GameObject
    {
        private Position localPosition;

        public string Name, Tag;
        //The reason for any gameobject having hitpoints is because
        //in our game we want anything to have the possibility of being destroyed
        //e.g. a tree can be cut, a box can be cracked open, an enemy can die
        //when the hitpoints of a GameObject reaches 0 that GameObject is removed from the game (it's destroyed)

        public double Hitpoints;
        public double MaxHitpoints;
        public void SetPosition(Position pos)
        {

            localPosition = pos;

        }

        public void SetPosition(int x, int y)
        {
            localPosition = new Position(x, y);
        }

        public GameObject(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }
        public void TakeDamage(double hitpoints)
        {
            OnDamage(ref hitpoints);
            this.Hitpoints -= hitpoints;
            if (this.Hitpoints == 0)
            {
                Die();

            }
        }
       virtual public void Die()
        {
            World.WorldInstance.Tiles[localPosition].Remove(this);
        }
        virtual public void OnDamage(ref double hitpoints) {
            
        }
        
        public Position GetPosition()
        {
            return localPosition;
        }

        public void Heal(double hitpoints)
        {
            this.Hitpoints += hitpoints;
            if (this.Hitpoints > MaxHitpoints)
                Hitpoints = MaxHitpoints;
        }
    }
}
