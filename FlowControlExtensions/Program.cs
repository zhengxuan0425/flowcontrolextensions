﻿using System;

namespace FlowControlExtensions
{
    internal class Program
    {
        private static void Main()
        {
            //Example8();
            Example10();

        }

        public static void Example1()
        {
            var person = new Person {Name = "Cosmo Kramer"};
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            person.Address.WriteToConsole();
            Console.ReadKey();
        }

        public static void Example2()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            if (person.Address != null)
            {
                person.Address.WriteToConsole();
            }
            Console.ReadKey();
        }

        public static void Example3()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            if (person.Address != null)
            {
                person.Address.WriteToConsole();
            }
            else
            {
                throw new NullReferenceException();
            }
            Console.ReadKey();
        }

        public static void Example4()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            person.Address.DoIfNotNull(a => a.WriteToConsole());
            Console.ReadKey();
        }

        public static void Example5()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            person.Address.DoIfNotNull(a => a.WriteToConsole(), doContinue : false);
            Console.ReadKey();
        }

        public static void Example6()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            Console.WriteLine(person.Address.ToString());
            Console.ReadKey();
        }

        public static void Example7()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            Console.WriteLine(person.Address.IfNotNull(a => a.ToString()));
            Console.ReadKey();
        }

        public static void Example8()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            Console.WriteLine(person.Address.IfNotNull(a => a.ToString(), doContinue : false));
            Console.ReadKey();
        }

        public static void Example9()
        {
            var person = new Person { Name = "Cosmo Kramer" };
            Console.WriteLine("Person: {0}", person.Name);
            Console.WriteLine("Address:");
            Console.WriteLine(person.Address.IfNotNull(a => a.ToString(), defaultValue : "(unknown)"));
            Console.ReadKey();
        }

        public static void Example10()
        {
            var person = new Person {Name = "Jackie Chiles", Citizenship = Nationality.Us };
            Console.Write("Citizenship:");
            Console.Write(person.Citizenship.Value);
            Console.ReadKey();
        }

        public static void Example11()
        {
            var person = new Person { Name = "Jackie Chiles", Citizenship = Nationality.Us };
            Console.Write("Citizenship:");
            Console.Write(person.Citizenship.IfHasValue(c => c.ToString()));
            Console.ReadKey();
        }
        public static void Example12()
        {
            var person = new Person { Name = "Jackie Chiles", Citizenship = Nationality.Us };
            Console.Write("Citizenship:");
            Console.Write(person.Citizenship.IfHasValue(c => c.ToString(), defaultValue: "(unknown)"));
            Console.ReadKey();
        }
    }

    enum Nationality
    {
        No,Se,Dk,Uk,Us
    }

    internal class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Nationality? Citizenship { get; set; }
    }

    internal class Address
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        
        public void WriteToConsole()
        {
            Console.WriteLine(Street);
            Console.WriteLine("{0} {1}", City, PostalCode);
        }

        public override string ToString()
        {
            return string.Format("{0}\n\r{1} {2}", Street, City, PostalCode);
        }
    }
}