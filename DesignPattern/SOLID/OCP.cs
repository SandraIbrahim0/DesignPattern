namespace DesignPattern.SOLID
{
    public class OCP
    {
        public enum Color
        {
            Red, Green, Blue
        }
        public enum Size
        {
            Small, Medium, Large, Yuge
        }
        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;

            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }
        }
        public interface ISpecification<T>
        {
            bool isStatisfied(T item);
        }
        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> codition);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color _color;
            public ColorSpecification(Color color)
            {
                _color = color;
            }
            public bool isStatisfied(Product item) => item.Color == _color;
        }

        public class AddSpecification : ISpecification<Product>
        {
            private Color _color;
            private Size _size;
            public AddSpecification(Color color, Size size)
            {
                _color = color;
                _size = size;
            }
            public bool isStatisfied(Product item) => item.Color == _color && item.Size == _size;
        }
        public class SizeSpecification : ISpecification<Product>
        {
            private Size _size;
            public SizeSpecification(Size size)
            {
                _size = size;
            }
            public bool isStatisfied(Product item) => item.Size == _size;
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> codition)
            {
                foreach (var item in items)
                {
                    if (codition.isStatisfied(item)) yield return item;
                }
            }
        }

    }
}
