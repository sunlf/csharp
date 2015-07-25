using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDEV.Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskTest();
        }

        static void TaskTest()
        {
            Task<int> primeNumber = Task.Run(() =>
                Enumerable.Range(2, 300000).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n / i > 0)));
            var awatiter = primeNumber.GetAwaiter();
            awatiter.OnCompleted(() =>
            {
                int result = awatiter.GetResult();
                Console.WriteLine("The result is" + result);
            });
            Console.ReadKey();
        }
    }
}
