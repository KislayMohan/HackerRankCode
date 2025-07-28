using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class HighAccessEmployee
    {
        public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
        {
            Dictionary<string, List<String>> employeeData = new Dictionary<string, List<String>>();
            HashSet<string> highAccessEmployees = new HashSet<string>();
            foreach (var item in access_times)
            {
                if (!employeeData.ContainsKey(item[0]))
                {
                    employeeData[item[0]] = new List<string>();
                }
                employeeData[item[0]].Add(item[1]);
            }

            foreach (var item in employeeData)
            {
                item.Value.Sort();
                for (int i = 0; i < item.Value.Count - 2; i++)
                {
                    if (Convert.ToInt32(item.Value.ElementAt(i+2)) - Convert.ToInt32(item.Value.ElementAt(i)) < 100)
                    { 
                        highAccessEmployees.Add(item.Key);
                        break;
                    }
                }
            }

            return highAccessEmployees.ToList();
        }
    }
}
