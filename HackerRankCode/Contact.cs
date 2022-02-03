using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public static class Contact
    {
        public static void ContactProb()
        {
            int queriesRows = Convert.ToInt32(Console.ReadLine().Trim());
            List<List<string>> queries = new List<List<string>>();
            for (int i = 0; i < queriesRows; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }
            List<int> result = ContactsSol(queries);
            Console.WriteLine(String.Join("\n", result));
        }

        private static List<int> ContactsSol(List<List<string>> queries)
        {
            var names = new Dictionary<string,int>();
            var contactOcc = new List<int>();
            foreach (var query in queries)
            {
                if (query[0] == "add")
                {
                    for (int i = 0; i < query[1].Length; i++)
                    {
                        var substr = query[1].Substring(0, i + 1);
                        if (!names.ContainsKey(substr))
                        {
                            names[substr] = 1;
                        }
                        else
                        {
                            names[substr]++;
                        }
                    }
                }
                else
                {
                    if (names.ContainsKey(query[1]))
                    {
                        contactOcc.Add(names[query[1]]);
                    }
                    else
                    {
                        contactOcc.Add(0);
                    }
                }
            }

            return contactOcc;
        }
    }
}
