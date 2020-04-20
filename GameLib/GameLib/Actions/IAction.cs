using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    public interface IAction
    {
        void Act(GameObject target);
       string Name {
            get;
            set;
        }

      
    }
}
