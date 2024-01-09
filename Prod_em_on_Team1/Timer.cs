using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class Timer
    {
        public Timer() { }
        
        public void Update()
        {
            if(Active)
            {

            }
        }
        public bool Active 
        {
            get; set;
        }
        public float TimePassed
        {
            get; private set;
        }
    }
}
