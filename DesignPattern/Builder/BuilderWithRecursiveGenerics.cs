using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
    public class BuilderWithRecursiveGenerics
    {
        public class Person
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public DateTime DateOfBirth { get; set; }

            public class Builder : PersonBirthDateBuilder<Builder>
            {
                internal Builder() { }
            }
            public static Builder New => new Builder();
            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position} , {nameof(DateOfBirth)}: {DateOfBirth}";
            }

        }

        //more generic class
        public abstract class Builder
        {
            protected Person person = new Person();
            public Person Build() { return person; }
        }
        //recursively  use the Self join to make Chaining and acheive that the child class know the base class
        public class PersonInfoBuilder<Self> : Builder where Self : PersonInfoBuilder<Self>
        {
            public Self Called(string name)
            {
                person.Name = name;
                return (Self)this;
            }
        }
        public class PersonJobBuilder<Self> : PersonInfoBuilder<PersonJobBuilder<Self>> where Self : PersonJobBuilder<Self>
        {
            public Self WorksAt(string position)
            {
                person.Position = position;
                return (Self)this;
            }
        }
        public class PersonBirthDateBuilder<Self> : PersonJobBuilder<PersonBirthDateBuilder<Self>> where Self : PersonBirthDateBuilder<Self>
        {
            public Self BornAt(DateTime dateTime)
            {
                person.DateOfBirth = dateTime;
                return (Self)this;
            }
        }

    }
}