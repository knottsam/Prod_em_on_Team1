﻿using Microsoft.Xna.Framework;


namespace Prod_em_on_Team1
{
    internal class Timer
    {
        private bool _active = true;
        private double _timeStarted;
        public Timer() { }
        
        public void Update(GameTime gameTime)
        {
            if(_active)
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
