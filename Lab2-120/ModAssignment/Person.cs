using System;
using System.Collections.Generic;
using System.Text;

namespace ModAssignment
{
    public abstract class Person
    {

        public string Name;

        public string PersonName()
        {
            return this.Name;
        }

        public Person(string name)
        {
            this.Name = name;
        }

    }
}
