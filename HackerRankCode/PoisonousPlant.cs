using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class PoisonousPlant
    {
        public static int poisonousPlants(int[] p)
        {
            int days = 0;
            var plantStack = new Stack<int>(p.Reverse());
            var plantList = new List<int>();
            while (plantStack.Count() > 0)
            {
                var planStackCount = plantStack.Count();
                var lastChecked = plantStack.Pop();
                plantList.Add(lastChecked);
                while (plantStack.Count() > 0)
                {
                    var currentPlant = plantStack.Pop();
                    if (lastChecked >= currentPlant)
                    {
                        plantList.Add(currentPlant);
                    }
                    lastChecked = currentPlant;
                }
                if (plantList.Count == planStackCount)
                {
                    break;
                }
                days++;
                plantList.Reverse();
                plantStack = new Stack<int>(plantList);
                plantList.Clear();
            }
            return days;

        }
    }
}
