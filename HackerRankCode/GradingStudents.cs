using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class GradingStudents
    {
        public static List<int> gradingStudents(List<int> grades)
        {
            var newGrades = new List<int>();
            foreach (var item in grades)
            {
                var diff = 5 - item % 5;
                if (item < 38 || diff >= 3)
                {
                    newGrades.Add(item);
                }
                else
                {
                    newGrades.Add(item + diff);
                }
            }
            return newGrades;
        }
    }
}
