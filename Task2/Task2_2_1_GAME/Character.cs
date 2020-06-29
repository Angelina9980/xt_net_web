using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1_GAME
{
    class Character:Unit
    {
        protected string name;
        protected int level, points, helth, speed;
        private int maxLevel = 20;
        protected void UpLevel()
        {
            if (points % 100 == 0 && level<maxLevel)
            {
                level++;
            }
            else if (level == 20)
            {
                Win();
            }
        }

        protected void EatBonus(Bonus bonus)
        {
            int benefit = bonus.benefit;
            points += benefit;
        }
        protected void damageHelth(Enemy enemy)
        {
            int damage = enemy.power;
            helth -= damage;
            if (helth <= 0)
            {
                Lose();
            }
        }

        protected void SpeedChanges(GameField gameFieldType)
        {
            if (gameFieldType.weather.Equals("sunny"))
            {
                speed += 5;
            }
            else if (gameFieldType.weather.Equals("wet"))
            {
                speed -= 5;
            }
            else if (gameFieldType.weather.Equals("icy"))
            {
                speed -= 15;
            }
            else if (gameFieldType.weather.Equals("rainy"))
            {
                speed -= 10;
            }
        }

        protected void Win()
        {
            Console.WriteLine("You are winner! Great!");
        }
     
        protected void Lose()
        {
            Console.WriteLine("Oooops, you lose \nYour scope is: {0} points", points);
        }
    }
}
