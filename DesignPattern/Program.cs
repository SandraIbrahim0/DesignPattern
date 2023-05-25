using DesignPattern.SOLID;
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

static  int Area(Rectangle r) => r.Width * r.Height;

Rectangle rc = new Rectangle(2, 3);
Console.WriteLine($"{rc} has area {Area(rc)}");


/*Square*/
Rectangle sq = new Square();
sq.Width = 4;
Console.WriteLine($"{sq} has area {Area(sq)}");