using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDEV.Collection.Enity
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}:{1} - {2}]", Id, Category, Value);
        }
    }
}
