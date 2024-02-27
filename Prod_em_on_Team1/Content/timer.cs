using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1.Content
{
    internal class timer
    {
        public bool _active = true;
        public double _timeStarted;
        public timer() { }

        public void Update(GameTime gameTime)
        {
            if (_active)
            {
                TimePassed = gameTime.TotalGameTime.TotalSeconds - _timeStarted;
            }
        }

        public void StartTimer(GameTime gameTime)
        {
            _active = true;
            _timeStarted = (float)gameTime.TotalGameTime.TotalSeconds;
        }
        public double GetTime()
        {
            _active = false;
            return TimePassed;
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public double TimePassed
        {
            get; private set;
        }

    }
}
