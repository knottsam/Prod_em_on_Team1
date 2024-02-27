using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class BikeTempBar
    {
        private readonly float _maxHealth;
        private float _health;
        private readonly ProgressBar _healthBar;

        public BikeTempBar(float health = 100f)
        {
            var back = Globals.Content.Load<Texture2D>("back");
            var front = Globals.Content.Load<Texture2D>("front");

            _maxHealth = health;
            _health = health;
            _healthBar = new(back, front, _maxHealth, new(100, 100));
        }

        public void TakeDamage(float dmg)
        {
            _health -= dmg;
            if (_health < 0) _health = 0;
        }

        public void Heal(float heal)
        {
            _health += heal;
            if (_health > _maxHealth) _health = _maxHealth;
        }

        public void Update()
        {
            if (InputManager.MouseLeftClicked) TakeDamage(10);
            if (InputManager.MouseRightClicked) Heal(10);

            _healthBar.Update(_health);
        }

        public void Draw()
        {
            _healthBar.Draw();
        }
    }
}
