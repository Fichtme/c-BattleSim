using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim
{
    class Pepe
    {
        public string Name { get; private set; }
        public int Healthpoints { get; private set; }

        private Random random;

        public Pepe(string name)
        {
            this.Name = name;
            this.Healthpoints = 100;
        }

        private int CalculateDamage() {
            this.random = new Random();
            return this.random.Next(0, 31);
        }

        public int DealDamage(Pepe target)
        {
            int damage = CalculateDamage();
            target.ReceiveDamage(damage);
            return damage;
        }

        public int ReceiveDamage(int damage)
        {
            this.Healthpoints -= damage;
            return damage;
        }

        public bool IsDead()
        {
            return Healthpoints < 0;
        }
    }
}
