using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    public class Orc : Character
    {

        int rage = 0;
        const int MaxRage = 100;
        bool berserker = false;

        public Orc(string _name) : base(_name)
        {
            rage = 0;
        }

        public override void GenerateStatus()
        {
            base.GenerateStatus();
            strenth = rand.Next(30) + 1;
            rage = 0;
        }

        public override void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃ 이름\t:{name,10}              ┃ ");
            Console.WriteLine($"┃ HP\t:{hp,4} / {maxHP,4}               ┃ ");
            Console.WriteLine($"┃ Rage\t:{rage,4} / {MaxRage,4}               ┃ ");
            Console.WriteLine($"┃ 힘\t:{strenth,3}                       ┃ ");
            Console.WriteLine($"┃ 민첩\t:{dexterity,3}                       ┃ ");
            Console.WriteLine($"┃ 지능\t:{intellegence,3}                       ┃ ");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }

        void BerserkerMode(bool on)
        {
            berserker = on;
            if (berserker)
            {
                strenth *= 2;
            }
            else
            {
                strenth = strenth >> 1;
            }
        }

        public override void TakeDamage(int damage)
        {
            rage += (int)(MaxRage * 0.1f + damage * 0.1f);
            if(rage >= MaxRage)
            {
                BerserkerMode(true);
            }

            base.TakeDamage(damage);
        }
    }
}