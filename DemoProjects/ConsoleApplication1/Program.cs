using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // new features in C# 6
            // null propagating operator
            // string interpolation
            // auto property initialisation
            // nameof operator
            Console.WriteLine($"Propertyname: {Person.FirstNamePropertyName}");

            var persons = new List<Person>();
            var p1 = new Person();
            persons.Add(p1);
            var p2 = new Person
            {
                FirstName = $"{p1.FirstName} Sepp"
            };
            persons.Add(p2);
            Person p3 = null;
            persons.Add(p3);
            
            // runtime exception filter with when
            foreach (var p in persons)
            {
                //var firstname = p?.FirstName;
                //if (firstname == null)
                //    firstname = "null";
                //Console.WriteLine($"{firstname} {p?.LastName}");
                try {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                } catch(NullReferenceException) when (p == null)
                {
                    Console.WriteLine("person is null");
                }
            }

            // new dictionary initializer
            //var dict = new Dictionary<int, Person>
            //{
            //    [1] = p1
            //};

            // expresson bodied members
            Console.WriteLine($"Fullname: {p1.GetFullName()}");

            Console.ReadKey();

        }
    }

    internal class Person
    {
        public string FirstName { get; set; } = "Max";

        public string LastName { get; set; } = "Mustermann";

        public static string FirstNamePropertyName
        {
            get
            {
                return nameof(FirstName);
            }
        }

        public string GetFullName() => FirstName + " " + LastName;

    }
}
