using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID
{
    public class DependencyInversion
    {
        //high level module should not depend on low level modul rather both depends on Interfaces ( abscartions)
        public enum Relationship
        {
            Parent,
            Child,
            Sibling
        }
        public class Person
        {
            public string Name;
            public DateTime DateOfBirth;
        }
        // rather use the interfaces
        public interface IRelationships
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
            void AddParentAndChild(Person person, Person child);
        }

        public class Relationships : IRelationships // low-level what if I decide to use Dictionaries ?? refactor low and high levels
        {
            private List<(Person person1, Relationship relation, Person person2)> relations
              = new List<(Person person1, Relationship relation, Person person2)>();

            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }
            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return relations.Where(x => x.person1.Name == name
                     && x.relation == Relationship.Parent).Select(r => r.person2);
            }
        }
        public class Research //high - level: find all of john's children
        {
            // the property mush be public from Relationships to be able to use it in Research
            public Research(IRelationships relationships, string name)
            {
                foreach (var p in relationships.FindAllChildrenOf(name))

                {
                    Console.WriteLine($"John has a child called {p.Name}");
                }
            }

        }

    }
}
