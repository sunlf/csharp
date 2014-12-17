using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpDEV.Collection
{
    public class CTest
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static void CWhere()
        {
            string[] names = { "sunlf", "Dick", "Harry" };
            IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);
            foreach (string name in filteredNames) Console.WriteLine(name);
        }
    }
}
