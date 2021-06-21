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

        public static int ImprovedpoisonousPlants(int[] p)
        {
            int days = 0;
            var LinkList = new LinkedList<List<int>>();
            var plantList = new List<int>();
            foreach (var item in p)
            {
                if (plantList.Count == 0)
                {
                    plantList.Add(item);
                    continue;
                }
                if (item <= plantList[plantList.Count - 1])
                {
                    plantList.Add(item);
                }
                else
                {
                    LinkList.AddLast(plantList);
                    plantList = new List<int>();
                    plantList.Add(item);
                }
            }
            if (plantList.Count > 0)
            {
                LinkList.AddLast(plantList);
            }
            if (LinkList.Count == 1)
            {
                return days;
            }
            while (LinkList.Count > 1)
            {
                var current = LinkList.First;
                while (current.Next != null)
                {
                    if (current.Next.Value.Count > 0)
                    {
                        current.Next.Value.RemoveAt(0);
                    }

                    if ((current.Next.Value.Count > 0 && current.Value.Last() > current.Next.Value.First()) || current.Next.Value.Count == 0)
                    {
                        if (current.Next.Value.Count > 0)
                        {
                            current.Value.AddRange(current.Next.Value);
                        }
                        LinkList.Remove(current.Next);
                        continue;
                    }
                    current = current.Next;
                }
                days++;
            }
            return days;
        }
    }
}
