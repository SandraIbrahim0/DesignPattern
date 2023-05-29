using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Builder.BuilderWithRecursiveGenerics;
using static DesignPattern.Builder.FacadeBuilder;

namespace DesignPattern.Builder
{
    public class FacadeBuilder
    {
        // how to make multiple builder work toegther 
        // using facade to create class simplified that hides the complexity of the other implemntations

        public class Person
        {
            // address
            public string StreetAddress, Postcode, City;
            // employment
            public string CompanyName, Position;
            public int AnnualIncome;
            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }
        public class PersonBuilder  // facade
        {
            protected Person Person = new Person();
            public EmployementBuilder BuildEmployementDetails => new EmployementBuilder(Person);
            public AddressBuilder BuildAddressDetails => new AddressBuilder(Person);

            public static implicit operator Person(PersonBuilder personBuilder)
            {
                return personBuilder.Person;
            }
        }

        public class EmployementBuilder : PersonBuilder
        {
            public EmployementBuilder(Person person) { this.Person = person; }

            public EmployementBuilder WorksAt(string name)
            {
                Person.CompanyName = name;
                return this;
            }
            public EmployementBuilder As(string position)
            {
                Person.Position = position;
                return this;
            }
            public EmployementBuilder Earning(int annualIncome)
            {
                Person.AnnualIncome = annualIncome;
                return this;
            }
        }
        public class AddressBuilder : PersonBuilder
        {
            public AddressBuilder(Person person) { this.Person=person; }
            public AddressBuilder At(string streetAddress)
            {
                Person.StreetAddress = streetAddress;
                return this;
            }

            public AddressBuilder WithPostcode(string postcode)
            {
                Person.Postcode = postcode;
                return this;
            }

            public AddressBuilder In(string city)
            {
                Person.City = city;
                return this;
            }
        }

    }
}
