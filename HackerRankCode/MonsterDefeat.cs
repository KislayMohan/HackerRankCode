using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MonsterDefeat
    {
        public static void MonsterDefeatSol()
        {
            var monsterInput = Console.ReadLine();
            var monsters = monsterInput.Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            var hitPoints = Convert.ToInt32(Console.ReadLine());
            var potions = Convert.ToInt32(Console.ReadLine());

            var result = MonsterFight(monsters, hitPoints, potions);
        }

        private static int MonsterFight(int[] monsters, int hitPoints, int potions)
        {
            var defeatIndex = 0;

            for (int i = 1; i < monsters.Length; i++)
            {
                if (monsters[i] < monsters[i-1])
                {
                    defeatIndex = i;
                }
                else
                {
                    if (hitPoints >= monsters[i] - monsters[i - 1])
                    {
                        defeatIndex = i;
                        hitPoints -= monsters[i] - monsters[i - 1];
                    }
                    else if(potions > 0)
                    {
                        potions--;
                        defeatIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return defeatIndex;
        }
    }
}
