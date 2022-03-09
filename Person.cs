using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTest
{
    
    //Modifiers:
    //private is not accessible anywhere
    //protected is accessible via inheritance 
    //public is accessible everywhere 
    //internal class is accessible in the same assembly
    [MyDescription("Hello")]
    [Priority(10)]
    public class Person
    {
        public Person()
        {
            Console.WriteLine("Person is creating...");
        }

        //field definition 
        private int _id = 10;

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {

                if (value.Length > 10)
                {

                    _name = value.Substring(0, 10);
                    ;
                }
                else
                {
                    _name = value;
                }
            }
        }

        //Auto property will create an underline field and expose it via getter and setter
        public string FamilyName { get; set; }
        public int Age { get; set; }


        public string Introduce()
        {
            return "I am" + _name + "and I am" + Age + "years old.";
        }
    }
}
