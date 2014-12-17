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

        public static void LookUpTest()
        {
            List<Product> products = GetAllProducts();
            var lookUp = products.ToLookup(p=>p.Category,j=>j.ToString().ToUpper());
            foreach (var l in lookUp)
            {
                Console.WriteLine(l.Key);
                foreach (var item in l)
                {
                    Console.WriteLine("\t" + item);
                }   
            }
        }

        public static void GroupTest()
        {
            List<Product> products = GetAllProducts();
            foreach (var group in products.GroupBy(p => p.Category))
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }

        public static List<Product> GetAllProducts()
        {
            return new List<Product> {
                new Product{ Id = 1, Category ="Electroinics",Value=15.0},
                new Product{ Id = 2, Category ="Groceries",Value=40.0},
                new Product{ Id = 3, Category ="Garden",Value=210.3},
                new Product{ Id = 4, Category ="Pets",Value=2.1},
                new Product{ Id = 5, Category ="Electroinics",Value=19.95},
                new Product{ Id = 6, Category ="Pets",Value=21.25},
                new Product{ Id = 7, Category ="Pets",Value=5.50},
                new Product{ Id = 8, Category ="Garden",Value=13.10},
                new Product{ Id =9, Category ="Automotive",Value=10.0},
                new Product{ Id =10, Category ="Electroinics",Value=10.0}
            };
        }
    }
}
