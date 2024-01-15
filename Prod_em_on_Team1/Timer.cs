using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class Timer
    {
        private bool _active = true;
        public Timer() { }
        
        public void Update(GameTime gameTime)
        {
            if(_active)
            {
                TimePassed = (float)gameTime.TotalGameTime.TotalSeconds;
            }
        }
        public float GetTime()
        {
            _active = false;
            return TimePassed;
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public float TimePassed
        {
            get; private set;
        }
    }
}
