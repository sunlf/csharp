using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpDEV.Collection.Enity;

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

        public static void SelectManyTest()
        {
            PetOwner[] petOwners = 
                    { new PetOwner{ Name="Higa,Sidnety",Pets = new List<string>{"Scryffy","Sam"}},
                      new PetOwner{ Name="Ashkenaiz,Ronen",Pets = new List<string>{"Walker","Sugar"}},
                      new PetOwner{ Name="",Pets = new List<string>{"Scratches","Diesel"}}};
            
            IEnumerable<string> query1 = petOwners.SelectMany(petOwner =>petOwner.Pets);
            
            Console.WriteLine("Using SelectMany():");

            foreach (string pet in query1)
            {
                Console.WriteLine(pet);
            }

            IEnumerable<List<string>> query2 = petOwners.Select(petOwner => petOwner.Pets);

            Console.WriteLine("\n Using Select():");

            foreach (List<string> petList in query2)
            {
                foreach (string pet in petList)
                {
                    Console.WriteLine(pet);
                }
                Console.WriteLine();
            }
        }
    }
}
