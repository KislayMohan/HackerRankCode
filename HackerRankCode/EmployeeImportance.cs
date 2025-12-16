using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class EmployeeImportance
    {
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }

        public int GetImportance(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> empDict = new Dictionary<int, Employee>();
            foreach (var emp in employees)
            {
                empDict[emp.id] = emp;
            }
            return Dfs(empDict, id);
        }

        private int Dfs(Dictionary<int, Employee> empDict, int id)
        {
            Employee emp = empDict[id];
            int totalImportance = emp.importance;
            foreach (int subId in emp.subordinates)
            {
                totalImportance += Dfs(empDict, subId);
            }
            return totalImportance;
        }
    }
}
