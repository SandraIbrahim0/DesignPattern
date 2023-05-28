using DesignPattern.SOLID;
using System.Text;
using static DesignPattern.Builder.Builder;
using static DesignPattern.Builder.BuilderWithRecursiveGenerics;
using static DesignPattern.SOLID.DependencyInversion;
using static DesignPattern.SOLID.LiskovPrinciple;
using static DesignPattern.SOLID.OCP;

/*Single Responsibility*/
//var journal = new Journal();
//journal.AddEntry("First Entry");
//journal.AddEntry("Secand Entry");

//Console.WriteLine(journal);

//var persistance = new Presisitence();

//persistance.SaveFile(journal, "C:\\Study Projects\\Design Pattern\\Single.txt");


/*OCP*/

//var apple = new Product("Apple", Color.Green, Size.Small);
//var tree = new Product("Tree", Color.Green, Size.Large);
//var house = new Product("House", Color.Blue, Size.Large);

//Product[] products = { apple, tree, house };

//var betterFilter = new BetterFilter();
//Console.WriteLine("Green products :");
//foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
//    Console.WriteLine($" - {product.Name} is green");

//foreach (var product in betterFilter.Filter(products, new SizeSpecification(Size.Large)))
//    Console.WriteLine($" - {product.Name} is Large");

//foreach (var product in betterFilter.Filter(products, new AddSpecification(Color.Blue, Size.Large)))
//    Console.WriteLine($" - {product.Name} is Large and Blue");

/*Liskov Principle*/

//static  int Area(Rectangle r) => r.Width * r.Height;

//Rectangle rc = new Rectangle(2, 3);
//Console.WriteLine($"{rc} has area {Area(rc)}");


///*Square*/
//Rectangle sq = new Square();
//sq.Width = 4;
//Console.WriteLine($"{sq} has area {Area(sq)}");

//Dependency Inversion


//var parent = new Person { Name = "John" };
//var child1 = new Person { Name = "Chris" };
//var child2 = new Person { Name = "Matt" };

//// low-level module
//var relationships = new Relationships();
//relationships.AddParentAndChild(parent, child1);
//relationships.AddParentAndChild(parent, child2);

//var research = new Research(relationships,"John");


//builder 
// if you want to build a simple HTML paragraph using StringBuilder
//var hello = "hello";
//var stringBuilder = new StringBuilder();
//stringBuilder.Append("<p>");
//stringBuilder.Append(hello);
//stringBuilder.Append("</p>");
//Console.WriteLine(stringBuilder);

// now I want an HTML list with 2 words in it
//var words = new[] { "hello", "world" };
//stringBuilder.Clear();
//stringBuilder.Append("<ul>");
//foreach (var word in words)
//{
//    stringBuilder.AppendFormat("<li>{0}</li>", word);
//}
//stringBuilder.Append("</ul>");
//Console.WriteLine(stringBuilder);

// ordinary non-fluent builder
var builder = new HtmlBuilder("ul");
builder.AddChild("li", "hello").AddChild("li", "world");
Console.WriteLine(builder.ToString());

//// fluent builder
//sb.Clear();
//builder.Clear(); // disengage builder from the object it's building, then...
//builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
//WriteLine(builder);

var me = DesignPattern.Builder.BuilderWithRecursiveGenerics.Person.New
       .Called("Sandra")
       .WorksAt("Geidea")
       .BornAt(DateTime.UtcNow)
       .Build();
Console.WriteLine(me);