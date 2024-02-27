using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class GameManager
    {
        private readonly BikeTempBar _biketemp;

        public GameManager()
        {
            _biketemp = new();
        }

        public void Update()
        {
            InputManager.Update();
            _biketemp.Update();
        }

        public void Draw()
        {
            _biketemp.Draw();
        }
    }
}
