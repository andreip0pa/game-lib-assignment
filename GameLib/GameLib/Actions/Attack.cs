using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    class Attack : IAction
    {
        public double Damage;
     
        public string Name { get; set; }
        public void Act(GameObject target)
        {
           
            target.TakeDamage(Damage);
        }

     
        public Attack(string name)
        {
            Name = name;
        }
        
    }
}
