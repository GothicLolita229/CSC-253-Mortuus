using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class CombatSystem
    {
        //public int Hp = Player.HP;
        //public static int newHp = 0;
        //public static int damage = 0;

        delegate int GetHitPoints(int hp);
        public static int AttackPoints(int hp)
        {
            Random rand = new Random();
            //char userAction;

            int damage = rand.Next(1, 20);

            return damage;
        }
        public static int CalcHealth(int Hp, int damage)
        {
            Hp -= damage;
            return Hp;
        }

        GetHitPoints Damage = AttackPoints;
        
    }
}
/**
* CSC 253
* Lourdes Linares and Ciara McLaughlin
* This program is a maze/rpg text adventure game. 
*/
