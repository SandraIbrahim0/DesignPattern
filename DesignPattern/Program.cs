using DesignPattern.SOLID;
using static DesignPattern.SOLID.OCP;

/*Single Responsibility*/
//var journal = new Journal();
//journal.AddEntry("First Entry");
//journal.AddEntry("Secand Entry");

//Console.WriteLine(journal);

//var persistance = new Presisitence();

//persistance.SaveFile(journal, "C:\\Study Projects\\Design Pattern\\Single.txt");


/*OCP*/

var apple = new Product("Apple", Color.Green, Size.Small);
var tree = new Product("Tree", Color.Green, Size.Large);
var house = new Product("House", Color.Blue, Size.Large);

Product[] products = { apple, tree, house };

var betterFilter = new BetterFilter();
Console.WriteLine("Green products :");
foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
    Console.WriteLine($" - {product.Name} is green");

foreach (var product in betterFilter.Filter(products, new SizeSpecification(Size.Large)))
    Console.WriteLine($" - {product.Name} is Large");

foreach (var product in betterFilter.Filter(products, new AddSpecification(Color.Blue, Size.Large)))
    Console.WriteLine($" - {product.Name} is Large and Blue");