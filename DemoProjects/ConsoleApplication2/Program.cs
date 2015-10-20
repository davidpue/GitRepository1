using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // new features in C# 6
            // auto property initialisation
            // null propagating operator
            // string interpolation
            // nameof operator
            // runtime exception filter with when
            // new dictionary initializer
            // expresson bodied members
            var p = new Person();
            var p2 = new Person { LastName = "Mustermann2" };
            Person p3 = null;
            var persons = new List<Person>();
            persons.Add(p);
            persons.Add(p2);
            persons.Add(p3);
            persons = persons.Where(px => px.LastName.EndsWith("2")).ToList();
            persons.Clear();

            var dict = new Dictionary<int, Person>
            {
                [1] = p,
                [2] = p2
            };

            foreach (var pers in persons)
            {
                //string firstName = null;
                //if (pers != null)
                //    firstName = pers.FirstName;
                string firstName = null;
                try
                {
                    firstName = pers.FirstName;
                }
                catch (NullReferenceException ex) when (firstName == null)
                {

                }
                catch (NullReferenceException ex) when (firstName == null)
                {

                }
                catch (Exception ex)
                {

                }
                //string firstName = pers?.FirstName;
                //Console.WriteLine(string.Format("Firstname: {0}", firstName));
                Console.WriteLine($"Firstname: {pers?.FirstName}");
                
            }
        }

        class Person
        {
            public string FirstNamePropertyName
            {
                get
                {
                    return nameof(FirstName);
                }
            }

            public string FirstName { get; set; } = "Max";

            public string CalcFullName() => FirstName + " " + LastName;

            public string LastName { get; set; } = "Mustermann";
        }
    }
}
