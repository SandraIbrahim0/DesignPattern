using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
    public class Builder
    {
        //Builder uses when we need to build complex objects by simply build parts of them then chainning all toegther 
        public class HtmlElement
        {
            public string name, text;
            public List<HtmlElement> elements = new List<HtmlElement>();
            private const int indentSize = 2;
            public HtmlElement(string name ,string text)
            {
                this.name = name; 
                this.text = text;
            }
            public HtmlElement()
            {

            }
            private string ToStringImplementation(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', indentSize * indent);
                sb.Append($"{i}<{name}>\n");
                if (!string.IsNullOrWhiteSpace(text))
                {
                    sb.Append(new string(' ', indentSize * (indent + 1)));
                    sb.Append(text);
                    sb.Append("\n");
                }
                foreach (var e in elements)
                    sb.Append(e.ToStringImplementation(indent + 1));

                sb.Append($"{i}</{name}>\n");
                return sb.ToString();
            }
            public override string ToString()
            {
                return ToStringImplementation(0);
            }
        }
        public class HtmlBuilder
        {
            private readonly string rootName;
            HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                this.rootName = rootName;
                root.name = rootName;
            }

            // not fluent
            public HtmlBuilder AddChild(string childName, string childText)
            {
                var e = new HtmlElement(childName, childText);
                root.elements.Add(e);
                return this;
            }

            //public HtmlBuilder AddChildFluent(string childName, string childText)
            //{
            //    var e = new HtmlElement(childName, childText);
            //    root.Elements.Add(e);
            //    return this;
            //}

            public override string ToString()
            {
                return root.ToString();
            }

            public void Clear()
            {
                root = new HtmlElement { name = rootName };
            }


        }
    }
}
