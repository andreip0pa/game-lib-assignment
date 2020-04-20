using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Actions
{
    class Move : IAction
    {
        public string Name { get; set; }

        public void Act(GameObject target)
        {
           
        }

        public void Act(GameObject target,Direction direction)
        {
            Position newPosition = target.GetPosition();
            if (direction == Direction.North)
            {
                newPosition.y++;
                target.SetPosition(newPosition);
            }
            else if (direction == Direction.South)
            {
                newPosition.y--;
                target.SetPosition(newPosition);
            }
            else if (direction == Direction.East)
            {
                newPosition.x++;
                target.SetPosition(newPosition);
            }
            else if (direction == Direction.West)
            {
                newPosition.x--;
                target.SetPosition(newPosition);
            }
        }
    }
}
